Veri tabanı bağlantısı için;
WebProjesiSqlKomutları.txt dosyasını MS Server Management System -> new query
dedikten sonra kopyalayıp yapıştırın. Execute yapın.

Solution explorer-> web.config dosyası içerisinde;
<add name="teknomarketDB1Entities" connectionString="metadata=res://*/DAL1.Model1.csdl|res://*/DAL1.Model1.ssdl|res://*/DAL1.Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DESKTOP-N7P2C4M\SQLEXPRESS01;initial catalog=teknomarketDB1;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
tag'leri arasındaki source parametresini SQL Server connection adına göre güncelleyin.

Son olarak projeyi Build edin.