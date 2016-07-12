using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Ws.RestWs.Dto;

namespace Ws.RestWs.Satici
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISaticiWs" in both code and config file together.
    [ServiceContract]
    public interface ISaticiWs
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "allSatici")]
        List<SaticiDTO> allSaticiDTO();

        [OperationContract]
        [WebInvoke(Method = "POST",
             BodyStyle = WebMessageBodyStyle.WrappedRequest,
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "saticiDelete")]
        SaticiDTO deleteSatici(SaticiDTO satici, CalisanDTO calisan);

        [OperationContract]
        [WebInvoke(Method = "POST",
             BodyStyle = WebMessageBodyStyle.WrappedRequest,
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "SaticiUpdate")]
        SaticiDTO updateSatici(SaticiDTO satici, CalisanDTO calisan);

        [OperationContract]
        [WebInvoke(Method = "POST",
             BodyStyle = WebMessageBodyStyle.WrappedRequest,
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "SaticiCreate")]
        SaticiDTO createSatici(SaticiDTO satici, CalisanDTO calisan);
    }
}
