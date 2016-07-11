using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Ws.RestWs.Dto;

namespace Ws.RestWs.Firma
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFirmWs" in both code and config file together.
    [ServiceContract]
    public interface IFirmWs
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "firmCreate")]
        FirmDTO createFirm(FirmDTO firmDTO, CalisanDTO calisanDTO);

        [OperationContract]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "allFirm")]
        List<FirmDTO> allFirm();

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "firmUpdate")]
        FirmDTO updatedFirm(FirmDTO firmDTO, CalisanDTO calisanDTO);

        [OperationContract]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "firmListName/{name}")]
        List<FirmDTO> findbyName(string name);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "firmDelete")]
        FirmDTO DeleteFirm(FirmDTO firmDTO, CalisanDTO calisanDTO);

    }
}
