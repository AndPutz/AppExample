using AppExampleAPI.Models;

namespace AppExampleAPI.Extensions
{
    public static class ObjectTabResponseExtensions
    {
        public static ObjectTabResponse PrepareResult(this ObjectTabResponse response)
        {
            if (response.Item == null)
            {
                response.StatusCode = 500;
                response.Status = ObjectTabResponse.StatusEnum.ErrorEnum;
            }
            else if (response.Item.ID == -401)
            {
                response.StatusCode = 401;
                response.Status = ObjectTabResponse.StatusEnum.ErrorEnum;
            }
            else if (response.Item.ID > 0)
            {
                response.StatusCode = 200;
                response.Status = ObjectTabResponse.StatusEnum.OKEnum;
            }

            return response;
        }

        public static ObjectTabListResponse PrepareResult(this ObjectTabListResponse response)
        {
            if (response.Item == null)
            {
                response.StatusCode = 500;
                response.Status = ObjectTabListResponse.StatusEnum.ErrorEnum;
            }
            else if (response.Item[0].ID == -401)
            {
                response.StatusCode = 401;
                response.Status = ObjectTabListResponse.StatusEnum.ErrorEnum;
            }
            else if (response.Item.Count > 0)
            {
                response.StatusCode = 200;
                response.Status = ObjectTabListResponse.StatusEnum.OKEnum;
            }

            return response;
        }
    }
}
