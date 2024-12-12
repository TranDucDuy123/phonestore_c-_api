//using doan2vadt.database.entities;
//using doan2vadt.database;
//using microsoft.aspnetcore.mvc;
//using pagedlist.core;
//using microsoft.entityframeworkcore;
//using doan2vadt.helpper;
//using microsoft.aspnetcore.mvc.rendering;
//using aspnetcorehero.toastnotification.abstractions;
//using aspnetcorehero.toastnotification.notyf;

//namespace doan2vadt.controllers
//{
//    public class thongketonkhocontroller : controller
//    {
//        private readonly appdbcontext _context;
//        public inotyfservice _notyfservice { get; }

//        public thongketonkhocontroller(appdbcontext context, inotyfservice notyfservice)
//        {
//            _context = context;
//            _notyfservice = notyfservice;
//        }

//        // get: orders
//        public iactionresult index(int? page)
//        {
//            var pagenumber = page == null || page <= 0 ? 1 : page.value;
//            var pagesize = 8;
//            var lsbook = _context.products
//                .asnotracking()
//                .orderbydescending(x => x.createdat);
//            pagedlist<product> models = new pagedlist<product>(lsbook, pagenumber, pagesize);
//            viewbag.currentpage = pagenumber;
//            return view(models);
//        }
//        [httppost]
//        public iactionresult index(datetime from_date, datetime to_date)
//        {
//            using (_context)
//            {
//                viewbag.getbills = (from b in _context.products where b.createdat >= from_date && b.createdat <= to_date == true select b).tolist();
//                viewbag.getquantityorder = (from b in _context.products where b.createdat >= from_date && b.createdat <= to_date == true select b.id).count();
//                viewbag.import = (from b in _context.imports where b.createdat >= from_date && b.createdat <= to_date == true select b.id).count();
//                viewbag.getquantityimport = (from b in _context.imports where b.createdat >= from_date && b.createdat <= to_date == true select b.total).sum();
//                return view();
//            }
//        }
//        public iactionresult filtter(int catid = 0)
//        {
//            var url = $"/book?catid={catid}";
//            if (catid == 0)
//            {
//                url = $"/book";
//            }
//            return json(new { status = "success", redirecturl = url });
//        }


//        public async task<iactionresult> details(string? id)
//        {
//            if (id == null || _context.products == null)
//            {
//                return notfound();
//            }

//            var book = await _context.products
//                .include(b => b.category)
//                .include(b => b.branch)
//                .include(b => b.color)
//                .firstordefaultasync(m => m.id.tostring() == id);
//            if (book == null)
//            {
//                return notfound();
//            }

//            return view(book);
//        }
//        public async task<iactionresult> edit(string? id)
//        {
//            if (id == null || _context.products == null)
//            {
//                return notfound();
//            }

//            var book = await _context.products.findasync(id);
//            if (book == null)
//            {
//                return notfound();
//            }

//            viewdata["categoryid"] = new selectlist(_context.categories, "id", "name", book.categoryid);
//            viewdata["branchid"] = new selectlist(_context.branchs, "id", "name", book.branchid);
//            viewdata["colorid"] = new selectlist(_context.colors, "id", "name", book.colorid);
//            return view(book);
//        }

//        // post: admin/book/edit/5
//        // to protect from overposting attacks, enable the specific properties you want to bind to.
//        // for more details, see http://go.microsoft.com/fwlink/?linkid=317598.
//        [httppost]
//        [validateantiforgerytoken]
//        public async task<iactionresult> edit(string id, [bind("description,image,price,discount,distributorid,publisherid,authorid,titleid,categoryid,id,name,createdat,updatedat,deletedat,updateuserid,createuserid,amont")] product book, microsoft.aspnetcore.http.iformfile fthumb)
//        {
//            if (id != book.id.tostring())
//            {
//                return notfound();
//            }

//            if (modelstate.isvalid)
//            {
//                book.name = utilities.totitlecase(book.name);
//                if (fthumb != null)
//                {
//                    string extension = path.getextension(fthumb.filename);
//                    string image = utilities.seourl(book.name) + extension;
//                    book.image = await utilities.uploadfile(fthumb, @"book", image.tolower());
//                }
//                if (string.isnullorempty(book.name)) book.image = "default.jpg";
//                if (system.io.file.exists(book.name))
//                {
//                    system.io.file.delete(book.name);
//                }
//                book.updatedat = datetime.now;
//                _context.update(book);
//                await _context.savechangesasync();
//                _notyfservice.success("update mới thành công");
//                return redirecttoaction(nameof(index));
//            }
//            viewdata["categoryid"] = new selectlist(_context.categories, "id", "name", book.categoryid);
//            viewdata["branchid"] = new selectlist(_context.branchs, "id", "name", book.branchid);
//            viewdata["colorid"] = new selectlist(_context.colors, "id", "name", book.colorid);
//            return view(book);
//        }
//        public async task<iactionresult> delete(string? id)
//        {
//            if (id == null || _context.products == null)
//            {
//                return notfound();
//            }

//            var book = await _context.products
//                .include(b => b.category)
//                .include(b => b.branch)
//                .include(b => b.color)
//                .firstordefaultasync(m => m.id.tostring() == id);
//            if (book == null)
//            {
//                return notfound();
//            }

//            return view(book);
//        }
//        [httppost, actionname("delete")]
//        [validateantiforgerytoken]
//        public async task<iactionresult> deleteconfirmed(string id, microsoft.aspnetcore.http.iformfile fthumb)
//        {
//            if (_context.products == null)
//            {
//                return problem("entity set 'appdbcontext.books'  is null.");
//            }
//            var book = await _context.products.findasync(id);
//            if (book != null)
//            {
//                book.name = utilities.totitlecase(book.name);
//                if (fthumb != null)
//                {
//                    string extension = path.getextension(fthumb.filename);
//                    string image = utilities.seourl(book.name) + extension;
//                    book.image = await utilities.uploadfile(fthumb, @"book", image.tolower());
//                }
//                if (string.isnullorempty(book.name)) book.image = "default.jpg";
//                if (system.io.file.exists(book.name))
//                {
//                    system.io.file.delete(book.name);
//                }
//                _context.products.remove(book);
//            }

//            await _context.savechangesasync();
//            _notyfservice.success("xóa thành công");
//            return redirecttoaction(nameof(index));
//        }

//        private bool bookexists(string id)
//        {
//            return _context.products.any(e => e.id.tostring() == id);
//        }
//    }
//}
