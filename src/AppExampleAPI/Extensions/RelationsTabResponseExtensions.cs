using AppExampleAPI.Models;

namespace AppExampleAPI.Extensions
{
    public static class RelationsTabResponseExtensions
    {
        public static RelationsTabResponse PrepareResult(this RelationsTabResponse response)
        {
            if (response.Item == null)
            {
                response.StatusCode = 500;
                response.Status = RelationsTabResponse.StatusEnum.ErrorEnum;
                response.Message = "return a null object";
            }
            else if (response.Item.ID == -401)
            {
                response.StatusCode = 401;
                response.Status = RelationsTabResponse.StatusEnum.ErrorEnum;
            }
            else if (response.Item.ID > 0)
            {
                response.StatusCode = 200;
                response.Status = RelationsTabResponse.StatusEnum.OKEnum;
            }

            return response;
        }

        public static RelationsTabListResponse PrepareResult(this RelationsTabListResponse response)
        {
            if (response.Item == null)
            {
                response.StatusCode = 500;
                response.Status = RelationsTabListResponse.StatusEnum.ErrorEnum;
                response.Message = "return a null list object";
            }
            else if (response.Item[0].ID == -401)
            {
                response.StatusCode = 401;
                response.Status = RelationsTabListResponse.StatusEnum.ErrorEnum;
            }
            else if (response.Item.Count > 0)
            {
                response.StatusCode = 200;
                response.Status = RelationsTabListResponse.StatusEnum.OKEnum;
            }

            return response;
        }
    }
}
