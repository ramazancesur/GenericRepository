using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Ws.RestWs.Dto;

namespace Ws.RestWs.Urun
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUrunWs" in both code and config file together.
    [ServiceContract]
    public interface IUrunWs
    {
        [OperationContract]
        List<UrunDTO> getAll(CalisanDTO calisanDTO);

        [OperationContract]
        FirmDTO findByFirm(CalisanDTO calisanDTO, UrunDTO urun);

        [OperationContract]
        [WebInvoke(Method = "POST",
             BodyStyle = WebMessageBodyStyle.WrappedRequest,
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "UrunDelete")]
        UrunDTO deleteUrunDTO(UrunDTO urunDTO, CalisanDTO createdCalisanDTO, int firmID);

        [OperationContract]
        [WebInvoke(Method = "POST",
             BodyStyle = WebMessageBodyStyle.WrappedRequest,
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "UrunUpdate")]
        UrunDTO updateUrunDTO(UrunDTO urunDTO, CalisanDTO createdCalisanDTO);

        [OperationContract]
        [WebInvoke(Method = "POST",
             BodyStyle = WebMessageBodyStyle.WrappedRequest,
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "UrunCreate")]
        UrunDTO createUrunDTO(UrunDTO urunDTO, CalisanDTO createdCalisanDTO);

    }
}