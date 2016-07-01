using System.ServiceModel;
using System.ServiceModel.Web;
using testProject.Yetkiler;

namespace testProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRestServiceImpl" in both code and config file together.
    [ServiceContract]
    public interface IRestServiceImpl
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "yetkiler/{username}/{passwd}")]
        KullaniciYetkiBilgisi yetkiBilgisi(string username,string passwd);

    }
}
