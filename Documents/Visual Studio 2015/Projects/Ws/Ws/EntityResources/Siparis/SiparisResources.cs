using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using test2.EntityDao.Employee;
using test2.EntityDao.Order;
using test2.EntityDao.OrderDetails;
using test2.EntityDao.Payment;
using test2.EntityDao.PaymentDetails;
using test2.EntityDao.Price;
using test2.EntityDao.Stock;
using test2.EntityDao.StockDetails;
using Ws.Helper;
using Ws.Model;
using Ws.RestWs.Dto;

namespace Ws.EntityResources.Siparis
{
    public class SiparisResources
    {
        /*
         *         public MusteriDTO musteri { get; set; }
        public double totalAmount { get; set; }
        public List<UrunDTO> lstUruns { get; set; }
        //Musteri Sipariş Notu
        public string orderNotesCustom { get; set; }
        //Satıcı Sipariş Notu
        public string orderNotesSaler { get; set; }
        //KalanBorc
        public double remainDept { get; set; }
        //Teslimat Tarihi
        public DateTime deliveryDate { get; set; }


        Ana tablomuz order 
        */
        PaymentDao paymentDao;
        PaymentDetailsDao paymentDetailDao;
        OrderDao orderDao;
        OrderDetailsDao orderDetailDao;

        // İlerde kullamılacak 
        StockDao stockDao;
        StockDetailsDao stockDetailDao;

        CreateLog createLog;
        PriceDao priceDao;
        EmployeeDao empDao;

        public SiparisResources()
        {
            init();

        }
        private void init()
        {
            paymentDao = new PaymentDao();
            paymentDetailDao = new PaymentDetailsDao();
            orderDao = new OrderDao();
            orderDetailDao = new OrderDetailsDao();
            //  İlerde Kullanılacak
            stockDao = new StockDao();
            stockDetailDao = new StockDetailsDao();
            createLog = new CreateLog();
            priceDao = new PriceDao();
            empDao = new EmployeeDao();
        }
       

        public SiparisDTO createSiparisDTO(SiparisDTO siparis,OdemeDTO odeme,CalisanDTO calisan)
        {
            // ********** Payment *********** //
            payment payment = new payment();
            payment.isActive = 1;
            payment.creationDate = siparis.createTime;
            payment.updateDate = DateTime.Now;
            payment.paymentDate = odeme.createTime;
            payment.price = odeme.price;
            payment.remainPrice = odeme.remainCost;
            payment.paymentType =(int) odeme.paymentType;
            paymentDao.Add(payment);
            createLog.SaveLog(calisan, payment, 1);

            // ****** Order ******* //
            order order = new order();
            order.creationDate = siparis.createTime;
            order.updateDate = DateTime.Now;
            order.isActive = 1;
            order.deliveryStatus = (int)siparis.deliveryStatus;
            order.employeeID = siparis.calisanDTO.id;
            order.clientID = siparis.musteri.ID;
            order.totalPrice = siparis.totalAmount;
            order.paymentID = payment.id;
            order.firmID = siparis.calisanDTO.firmID;
            orderDao.Add(order);
            createLog.SaveLog(calisan, order, 1);

            // ********* Order Detail ******* //
            orderdetail orderDetail;
            foreach (var siparisDetail in siparis.lstSiparisDetail)
            { 
                orderDetail = new orderdetail();
                orderDetail.creationDate = siparis.createTime;
                orderDetail.updateDate = DateTime.Now;
                orderDetail.isActive = 1;
                orderDetail.orderID = order.id;
                orderDetail.isApproved = 1;
                orderDetail.amount = Convert.ToInt32(Math.Ceiling(siparisDetail.price));
                try
                {
                    orderDetail.priceID = priceDao.FindBy(x => x.productID == siparisDetail.urunDTO.ID).LastOrDefault().id;
                }
                catch
                {
                }
                orderDetail.unitSize = siparisDetail.unitSize;
                orderDetail.unitType =(int) siparisDetail.unitType;
                orderDetailDao.Add(orderDetail);
            }

            return siparis;
        }
    }
}