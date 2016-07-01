using testProject.Yetkiler;

namespace testProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RestServiceImpl" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RestServiceImpl.svc or RestServiceImpl.svc.cs at the Solution Explorer and start debugging.
    public class RestServiceImpl : IRestServiceImpl
    {
        public KullaniciYetkiBilgisi yetkiBilgisi(string username, string passwd)
        {
            Yetkiler.YetkiServiceClient yetki = new Yetkiler.YetkiServiceClient();
            yetki.ClientCredentials.UserName.UserName = username;
            yetki.ClientCredentials.UserName.Password = passwd;

            KullaniciYetkiBilgisi yetkiler = yetki.KullaniciYetkileriniGetir(null, null, true, null, null, null, null);
            return yetkiler;
        }
    }
}
