using AppExampleAPI.Models;

namespace AppExampleAPI.Extensions
{
    public static class TypeTabResponseExtensions
    {

        public static TypeTabListResponse PrepareResult(this TypeTabListResponse response)
        {
            if (response.Item == null)
            {
                response.StatusCode = 500;
                response.Status = TypeTabListResponse.StatusEnum.ErrorEnum;
            }
            else if (response.Item[0].Id == -401)
            {
                response.StatusCode = 401;
                response.Status = TypeTabListResponse.StatusEnum.ErrorEnum;
            }
            else if (response.Item.Count > 0)
            {
                response.StatusCode = 200;
                response.Status = TypeTabListResponse.StatusEnum.OKEnum;
            }

            return response;
        }
    }
}
