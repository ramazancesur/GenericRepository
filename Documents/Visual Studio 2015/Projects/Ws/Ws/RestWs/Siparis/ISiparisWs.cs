using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Ws.RestWs.Dto;

namespace Ws.RestWs.Siparis
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISiparisWs" in both code and config file together.
    [ServiceContract]
    public interface ISiparisWs
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "AllOdeme")]
        List<OdemeDTO> allOdeme();

        [OperationContract]
        [WebInvoke(Method = "GET",
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "allSiparisDetay")]
        List<SiparisDetailDTO> allSiparisDetay(SiparisDTO siparis, CalisanDTO calisanDTO);

        [OperationContract]
        [WebInvoke(Method = "GET",
                      ResponseFormat = WebMessageFormat.Json,
                      UriTemplate = "allSiparis")]
        List<SiparisDTO> allSiparis();

        [OperationContract]
        [WebInvoke(Method = "GET",
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "allOdemeDetay")]
        List<OdemeDetayDTO> allOdemeDetay(OdemeDTO odeme);

        [OperationContract]
        [WebInvoke(Method = "POST",
             BodyStyle = WebMessageBodyStyle.WrappedRequest,
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "OdemeDelete")]
        OdemeDTO deleteOdemeDTO(OdemeDTO odeme, CalisanDTO calisan);


        [OperationContract]
        [WebInvoke(Method = "POST",
             BodyStyle = WebMessageBodyStyle.WrappedRequest,
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "OdemeUpdate")]
        OdemeDTO updateOdemeDTO(OdemeDTO odeme, CalisanDTO calisan);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "OdemeCreate")]
        OdemeDTO createOdeme(OdemeDTO odeme, CalisanDTO calisan);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "SiparisUpdate")]
        SiparisDTO updateSiparisDTO(SiparisDTO siparis, OdemeDTO odeme, CalisanDTO calisan);

        [OperationContract]
        [WebInvoke(Method = "POST",
             BodyStyle = WebMessageBodyStyle.WrappedRequest,
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "SiparisDelete")]
        SiparisDTO deleteSiparisDTO(SiparisDTO siparis, OdemeDTO odeme, CalisanDTO calisan);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "CreateSiparis")]
        SiparisDTO createSiparisDTO(SiparisDTO siparis, OdemeDTO odeme, CalisanDTO calisan);
    }
}
