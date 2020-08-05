/* AK Google OAuth2 Athenticator */
/* Simple Task For AK Software */

/* 
این یک اپلیکیشن نمونه برای اجرای اعتبارسنجی گوگل برای اپ های
Android , iOS
می باشد که با استفاده از کامپوننت
Xamarin.Auth
پیاده سازی شده است. این پروژه هنگام شروع صرفا عمل اعتبارسنجی
را انجام خواهد داد و هیچگونه پیاده سازی دیگری مبنی بر
اجرای مرحله بعد از اعتبارسنجی ( نظیر پیمایش به صفحه دیگر ) ندارد

هرچند به منظور نشان دادن کار , متدهای 
OnAuthenticateCompleted() , OnAuthenticateFailed()
با تزریق وابستگی 
IAuthenticatorService
پیاده شده است.

به منظور راحتی در فهم کدها , اطلاعات مربوط به اعتبارسنجی 
مانند کلاینت آیدی ها , اسکوپ و دایرکت ها در یک کلاس به صورت استاتیک گردآوری شده
است. روش بهتر , ایجاد فایل کانفیگ برای هر پروژه به صورت جداگانه
می باشد.

برای تولید کلیدهای خصوصی و عمومی پروژه , دستور زیر 
keytool -keystore "My Local Debug.keystore" -list -v
برای محیط دیباگ استفاده شده است.

Test:

Win 10. Visual Studio 2019. ver 16.6.5
Android : [Debug],[Any CPU],[Pixel 3],[Pie 9.0],[API 28]

VMWare. xCode(11.x)
iOS : [Debug],[iPhoneSimulator],[ProMax 11] (V)

*/