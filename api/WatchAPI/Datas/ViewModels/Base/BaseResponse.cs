using System;
using WatchAPI.Shared.Utils;

namespace WatchAPI.Datas.ViewModels.Base
{
    public class BaseResponse<T>
    {
        /// <summary>
        /// Mã trạng thái trả về:
        /// 0: Thành công
        /// 1: Truy cập trái phép
        /// 2: Quyền truy cập bị từ chối
        /// 3: Đối tượng đã tồn tại
        /// 4: Đối tượng không tìm thấy
        /// 5: Đối tượng đã hết hạn
        /// 6: Sai thông số
        /// 7: Lỗi hệ thống
        /// 8: Đối tượng đã bị khoá
        /// 99: Lỗi không xác định
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Thông điệp tương ứng với mã trạng thái trả về
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public T? Data { get; set; }

        public BaseResponse()
        {
        }

        public BaseResponse(int code, string message, T? data)
        {
            Code = code;
            Message = message;
            Data = data;
        }
        public static string CreateMessage(int code, string subContent)
        {
            if (subContent == null) subContent = "Đối tượng";
            return code switch
            {
                ResStatusConst.Code.SUCCESS => ResStatusConst.Message.SUCCESS,
                ResStatusConst.Code.UNAUTHORIZED => ResStatusConst.Message.UNAUTHORIZED,
                ResStatusConst.Code.ALREADY_EXISTS => string.Format(ResStatusConst.Message.ALREADY_EXISTS, subContent),
                ResStatusConst.Code.NOT_FOUND => string.Format(ResStatusConst.Message.NOT_FOUND, subContent),
                ResStatusConst.Code.INVALID_PARAM => string.Format(ResStatusConst.Message.INVALID_PARAM, subContent),
                ResStatusConst.Code.SYSTEM_ERROR => ResStatusConst.Message.SYSTEM_ERROR,
                _ => ResStatusConst.Message.UNKNOWN,
            };
        }
    }
}
