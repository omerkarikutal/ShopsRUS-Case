#ShopsRus
Katmanlı Mimari yapısı kullanıldı.
Birçok entity modelinin unit test metodları yazıldı.(xunit)
Repository Pattern modeli kullanıldı.
mssql ve .net6 kullanıldı.
ef code first yaklaşımı kullanıldı.
Herhangi bir migration yapmanıza gerek yoktur , auto migrate olarak local db üzerinde db create olacaktır.
3 endpoint bulunmaktadır.
Discount içerisinde bulunan metod , kullanıcının ürünler ile birlikte gönderilen requestinde indirimi hesaplayıp dönüş yapar.
Invoice içerisinde 2 adet metod vardır.
CreateInvoice UserId ve Product listesi gönderildiğinde , kullanıcıya ait indirim hesaplanır , invoice ve detail tabloları doldurulur.
GetInvoice metodunda ise , invoice_number parametresine göre bir get işlemi yapılır ve detaylı bir response dönülür.

CreateInvoice ve CalculateDiscount metodu için kullanılan Json Request :
{
  "UserId":1,
  "Products":
  [
    {"Id":1,"Quantity":2},{"Id":2,"Quantity":2},{"Id":3,"Quantity":2}
  ]
}
Bu şekilde gönderilen request lerde , response alacaksınız.
