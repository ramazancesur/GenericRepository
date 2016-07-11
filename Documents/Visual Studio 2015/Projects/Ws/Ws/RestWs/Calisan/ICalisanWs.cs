using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Ws.RestWs.Dto;

namespace Ws.RestWs.Calisan
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICalisanWs" in both code and config file together.
    [ServiceContract]
    public interface ICalisanWs
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "allCalisan")]
        List<CalisanDTO> allCaliisanList();

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "calisanCreate")]
        CalisanDTO createCalisan(CalisanDTO calisanDTO, CalisanDTO createdCalisanDTO);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "calisanUpdate")]
        CalisanDTO updateEmployee(CalisanDTO calisanDTO, CalisanDTO createdCalisanDTO);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "CalisanRemove")]
        CalisanDTO removeCalisan(CalisanDTO calisanDTO, CalisanDTO createdCalisanDTO);
    }
}
