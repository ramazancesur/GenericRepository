using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Ws.Model;
using Ws.RestWs.Dto;

namespace Ws.RestWs.Musteri
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMusteriWs" in both code and config file together.
    [ServiceContract]
    public interface IMusteriWs
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
             BodyStyle = WebMessageBodyStyle.WrappedRequest,
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "MusteriFindByClient")]
        MusteriDTO findMusteriByClient(client client);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "allClient")]
        List<MusteriDTO> lstMusteriDTO();

        [OperationContract]
        [WebInvoke(Method = "POST",
             BodyStyle = WebMessageBodyStyle.WrappedRequest,
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "MusteriUpdate")]
        MusteriDTO updateMusteri(MusteriDTO musteri, CalisanDTO calisan);

        [OperationContract]
        [WebInvoke(Method = "POST",
             BodyStyle = WebMessageBodyStyle.WrappedRequest,
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "MusteriDelete")]
        MusteriDTO deleteMusteri(MusteriDTO musteri, CalisanDTO calisan);

        [OperationContract]
        [WebInvoke(Method = "POST",
             BodyStyle = WebMessageBodyStyle.WrappedRequest,
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "MusteriCreate")]
        MusteriDTO createMusteri(MusteriDTO musteri, CalisanDTO calisan);

    }
}
