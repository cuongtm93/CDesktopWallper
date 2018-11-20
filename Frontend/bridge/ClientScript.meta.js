Bridge.assembly("ClientScript", function ($asm, globals) {
    "use strict";


    var $m = Bridge.setMetadata,
        $n = ["System","System.Threading.Tasks","Kernel","System.Collections.Generic","CDesktopWallper","ClientScript"];
    $m("support", function () { return {"att":1048961,"a":2,"s":true,"m":[{"a":2,"n":"clearInnerHtml","is":true,"t":8,"pi":[{"n":"element","pt":HTMLElement,"ps":0}],"sn":"clearInnerHtml","rt":$n[0].Void,"p":[HTMLElement]},{"a":2,"n":"plusText","is":true,"t":8,"pi":[{"n":"element","pt":HTMLElement,"ps":0},{"n":"text","pt":$n[0].String,"ps":1}],"sn":"plusText","rt":$n[0].Void,"p":[HTMLElement,$n[0].String]}]}; }, $n);
    $m("Javascript", function () { return {"att":1048961,"a":2,"s":true,"m":[{"a":2,"n":"debugger","is":true,"t":8,"tpc":0,"def":function () { return debugger; },"rt":$n[0].Void},{"a":2,"n":"typeof","is":true,"t":8,"pi":[{"n":"variable","pt":System.Object,"ps":0}],"tpc":0,"def":function (variable) { return typeof(variable); },"rt":$n[0].String,"p":[System.Object]}]}; }, $n);
    $m("Json", function () { return {"att":1048961,"a":2,"s":true,"m":[{"a":2,"n":"Parse","is":true,"t":8,"pi":[{"n":"json","pt":$n[0].String,"ps":0}],"sn":"Parse","rt":$n[0].Object,"p":[$n[0].String]},{"a":2,"n":"Stringify","is":true,"t":8,"pi":[{"n":"data","pt":System.Object,"ps":0}],"sn":"Stringify","rt":$n[0].String,"p":[System.Object]}]}; }, $n);
    $m("Kernel.Ajax", function () { return {"att":1048577,"a":2,"at":[new Kernel.Attributes.TestedAttribute("")],"m":[{"a":2,"n":".ctor","t":1,"sn":"ctor"},{"at":[new Kernel.Attributes.TestedAttribute("")],"v":true,"a":2,"n":"PrepareAjaxOptions","t":8,"sn":"PrepareAjaxOptions","rt":$n[0].Void},{"at":[new Kernel.Attributes.TestedAttribute("")],"v":true,"a":2,"n":"Request","t":8,"sn":"Request","rt":$n[0].Void},{"v":true,"a":2,"n":"SetDefaultParameters","t":8,"sn":"SetDefaultParameters","rt":$n[0].Void},{"at":[new Kernel.Attributes.TestedAttribute("")],"v":true,"a":2,"n":"ShowMessageForNotValidRequest","t":8,"sn":"ShowMessageForNotValidRequest","rt":$n[0].Void},{"v":true,"a":2,"n":"ShowNotSupportMethod","t":8,"sn":"ShowNotSupportMethod","rt":$n[0].Void},{"at":[new Kernel.Attributes.TestedAttribute("")],"v":true,"a":2,"n":"ValidateRequest","t":8,"sn":"ValidateRequest","rt":$n[0].Void},{"v":true,"a":2,"n":"Async","t":16,"rt":$n[0].Boolean,"g":{"v":true,"a":2,"n":"get_Async","t":8,"rt":$n[0].Boolean,"fg":"Async","box":function ($v) { return Bridge.box($v, System.Boolean, System.Boolean.toString);}},"s":{"v":true,"a":2,"n":"set_Async","t":8,"p":[$n[0].Boolean],"rt":$n[0].Void,"fs":"Async"},"fn":"Async"},{"v":true,"a":2,"n":"Method","t":16,"rt":$n[0].String,"g":{"v":true,"a":2,"n":"get_Method","t":8,"rt":$n[0].String,"fg":"Method"},"s":{"v":true,"a":2,"n":"set_Method","t":8,"p":[$n[0].String],"rt":$n[0].Void,"fs":"Method"},"fn":"Method"},{"v":true,"a":2,"n":"Url","t":16,"rt":$n[0].String,"g":{"v":true,"a":2,"n":"get_Url","t":8,"rt":$n[0].String,"fg":"Url"},"s":{"v":true,"a":2,"n":"set_Url","t":8,"p":[$n[0].String],"rt":$n[0].Void,"fs":"Url"},"fn":"Url"},{"v":true,"a":2,"n":"data","t":16,"rt":System.Object,"g":{"v":true,"a":2,"n":"get_data","t":8,"rt":System.Object,"fg":"data"},"s":{"v":true,"a":2,"n":"set_data","t":8,"p":[System.Object],"rt":$n[0].Void,"fs":"data"},"fn":"data"},{"v":true,"a":2,"n":"error","t":16,"rt":Function,"g":{"v":true,"a":2,"n":"get_error","t":8,"rt":Function,"fg":"error"},"s":{"v":true,"a":2,"n":"set_error","t":8,"p":[Function],"rt":$n[0].Void,"fs":"error"},"fn":"error"},{"v":true,"a":2,"n":"success","t":16,"rt":Function,"g":{"v":true,"a":2,"n":"get_success","t":8,"rt":Function,"fg":"success"},"s":{"v":true,"a":2,"n":"set_success","t":8,"p":[Function],"rt":$n[0].Void,"fs":"success"},"fn":"success"},{"a":1,"n":"_isValidRequest","t":4,"rt":$n[0].Boolean,"sn":"_isValidRequest","box":function ($v) { return Bridge.box($v, System.Boolean, System.Boolean.toString);}},{"a":2,"n":"request","t":4,"rt":Bridge.virtualc("JQuery.jqXHR"),"sn":"request"}]}; }, $n);
    $m("Kernel.AjaxTask", function () { return {"att":1048577,"a":2,"at":[new Kernel.Attributes.TestedAttribute("")],"m":[{"a":2,"n":".ctor","t":1,"sn":"ctor"},{"at":[new Kernel.Attributes.TestedAttribute("")],"a":2,"n":"Execute","t":8,"sn":"Execute","rt":$n[1].Task$1(System.Object)},{"a":1,"n":"_errorTask","t":8,"pi":[{"n":"jqXHR","pt":Bridge.virtualc("JQuery.jqXHR"),"ps":0},{"n":"textStatus","pt":System.String,"ps":1},{"n":"errorThrown","pt":$n[0].String,"ps":2}],"sn":"_errorTask","rt":$n[0].Void,"p":[Bridge.virtualc("JQuery.jqXHR"),System.String,$n[0].String]},{"at":[new Kernel.Attributes.TestedAttribute("")],"a":1,"n":"_sucessTask","t":8,"pi":[{"n":"data","pt":$n[0].Object,"ps":0},{"n":"textStatus","pt":System.String,"ps":1},{"n":"jqXHR","pt":Bridge.virtualc("JQuery.jqXHR"),"ps":2}],"sn":"_sucessTask","rt":$n[0].Void,"p":[$n[0].Object,System.String,Bridge.virtualc("JQuery.jqXHR")]},{"a":2,"n":"AjaxResult","t":16,"rt":$n[0].Object,"g":{"a":2,"n":"get_AjaxResult","t":8,"rt":$n[0].Object,"fg":"AjaxResult"},"s":{"a":2,"n":"set_AjaxResult","t":8,"p":[$n[0].Object],"rt":$n[0].Void,"fs":"AjaxResult"},"fn":"AjaxResult"},{"a":2,"n":"TimeCanWait","t":16,"rt":$n[0].Int32,"g":{"a":2,"n":"get_TimeCanWait","t":8,"rt":$n[0].Int32,"fg":"TimeCanWait","box":function ($v) { return Bridge.box($v, System.Int32);}},"s":{"a":2,"n":"set_TimeCanWait","t":8,"p":[$n[0].Int32],"rt":$n[0].Void,"fs":"TimeCanWait"},"fn":"TimeCanWait"},{"a":2,"n":"requestError","t":16,"rt":$n[0].Boolean,"g":{"a":2,"n":"get_requestError","t":8,"rt":$n[0].Boolean,"fg":"requestError","box":function ($v) { return Bridge.box($v, System.Boolean, System.Boolean.toString);}},"s":{"a":2,"n":"set_requestError","t":8,"p":[$n[0].Boolean],"rt":$n[0].Void,"fs":"requestError"},"fn":"requestError"}]}; }, $n);
    $m("Kernel.SelectorExtensions", function () { return {"att":1048961,"a":2,"s":true,"m":[{"a":2,"n":"Class","is":true,"t":8,"pi":[{"n":"name","pt":$n[0].String,"ps":0}],"sn":"Class","rt":$n[0].String,"p":[$n[0].String]},{"a":2,"n":"Id","is":true,"t":8,"pi":[{"n":"name","pt":$n[0].String,"ps":0}],"sn":"Id","rt":$n[0].String,"p":[$n[0].String]},{"a":2,"n":"Tag","is":true,"t":8,"pi":[{"n":"name","pt":$n[0].String,"ps":0}],"sn":"Tag","rt":$n[0].String,"p":[$n[0].String]}]}; }, $n);
    $m("Kernel.KendoDatePicker", function () { return {"att":1048577,"a":2,"m":[{"a":2,"n":".ctor","t":1,"p":[$n[0].String],"pi":[{"n":"Id","pt":$n[0].String,"ps":0}],"sn":"ctor"},{"a":2,"n":"GetDateTime","t":8,"sn":"GetDateTime","rt":$n[0].String},{"a":2,"n":"ReadOnly","t":8,"sn":"ReadOnly","rt":$n[0].Void},{"a":2,"n":"SetDateTime","t":8,"pi":[{"n":"dateTime","pt":$n[0].DateTime,"ps":0}],"sn":"SetDateTime","rt":$n[0].Void,"p":[$n[0].DateTime]},{"a":2,"n":"SetToday","t":8,"sn":"SetToday","rt":$n[0].Void},{"a":2,"n":"getFullWidth","t":8,"sn":"getFullWidth","rt":$n[0].Void},{"a":2,"n":"datePicker","t":16,"rt":System.Object,"g":{"a":2,"n":"get_datePicker","t":8,"rt":System.Object,"fg":"datePicker"},"s":{"a":2,"n":"set_datePicker","t":8,"p":[System.Object],"rt":$n[0].Void,"fs":"datePicker"},"fn":"datePicker"},{"a":2,"n":"object","t":16,"rt":HTMLInputElement,"g":{"a":2,"n":"get_object","t":8,"rt":HTMLInputElement,"fg":"object"},"fn":"object"},{"a":2,"n":"this","t":16,"rt":$n[2].KendoDatePicker,"g":{"a":2,"n":"get_this","t":8,"rt":$n[2].KendoDatePicker,"fg":"this"},"fn":"this"},{"a":2,"n":"_kendoDatePickerId","t":4,"rt":$n[0].String,"sn":"_kendoDatePickerId"},{"a":2,"n":"jquery","t":4,"rt":System.Object,"sn":"jquery"},{"a":2,"n":"kendo","t":4,"rt":System.Object,"sn":"kendo"}]}; }, $n);
    $m("Kernel.KendoDatePickerEventHandler", function () { return {"att":1048577,"a":2,"m":[{"a":2,"n":".ctor","t":1,"p":[$n[0].String],"pi":[{"n":"Id","pt":$n[0].String,"ps":0}],"sn":"ctor"},{"v":true,"a":2,"n":"onChange","t":8,"pi":[{"n":"obj","pt":$n[0].Object,"ps":0}],"sn":"onChange","rt":$n[0].Void,"p":[$n[0].Object]},{"v":true,"a":2,"n":"onClick","t":8,"pi":[{"n":"obj","pt":$n[0].Object,"ps":0}],"sn":"onClick","rt":$n[0].Void,"p":[$n[0].Object]},{"v":true,"a":2,"n":"onHover","t":8,"pi":[{"n":"obj","pt":$n[0].Object,"ps":0}],"sn":"onHover","rt":$n[0].Void,"p":[$n[0].Object]}]}; }, $n);
    $m("Kernel.DatePicker", function () { return {"att":1048577,"a":2,"m":[{"a":2,"n":".ctor","t":1,"sn":"ctor"},{"ov":true,"a":2,"n":"onChange","t":8,"pi":[{"n":"obj","pt":$n[0].Object,"ps":0}],"sn":"onChange","rt":$n[0].Void,"p":[$n[0].Object]},{"ov":true,"a":2,"n":"onClick","t":8,"pi":[{"n":"obj","pt":$n[0].Object,"ps":0}],"sn":"onClick","rt":$n[0].Void,"p":[$n[0].Object]},{"ov":true,"a":2,"n":"onHover","t":8,"pi":[{"n":"obj","pt":$n[0].Object,"ps":0}],"sn":"onHover","rt":$n[0].Void,"p":[$n[0].Object]}]}; }, $n);
    $m("Kernel.Class", function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"}]}; }, $n);
    $m("Kernel.Function", function () { return {"att":1048577,"a":2,"m":[{"a":2,"n":".ctor","t":1,"sn":"ctor"},{"v":true,"a":2,"n":"Execute","t":8,"sn":"Execute","rt":$n[0].Void},{"v":true,"a":2,"n":"VariablesInit","t":8,"sn":"VariablesInit","rt":$n[0].Void}]}; }, $n);
    $m("Kernel.Others.IFunction", function () { return {"att":160,"a":4,"m":[{"ab":true,"a":2,"n":"Execute","t":8,"pi":[{"n":"args","ip":true,"pt":System.Array.type(System.Object),"ps":0}],"sn":"Kernel$Others$IFunction$Execute","rt":System.Object,"p":[System.Array.type(System.Object)]}]}; }, $n);
    $m("Kernel.Others.IVoid", function () { return {"att":160,"a":4,"m":[{"ab":true,"a":2,"n":"Execute","t":8,"sn":"Kernel$Others$IVoid$Execute","rt":$n[0].Void}]}; }, $n);
    $m("Kernel.Http.HttpMethod", function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"DELETE","is":true,"t":4,"rt":$n[0].String,"sn":"DELETE"},{"a":2,"n":"GET","is":true,"t":4,"rt":$n[0].String,"sn":"GET"},{"a":2,"n":"PATCH","is":true,"t":4,"rt":$n[0].String,"sn":"PATCH"},{"a":2,"n":"POST","is":true,"t":4,"rt":$n[0].String,"sn":"POST"},{"a":2,"n":"PUT","is":true,"t":4,"rt":$n[0].String,"sn":"PUT"}]}; }, $n);
    $m("Kernel.Dependecies.DI", function () { return {"att":1048576,"a":4,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"ov":true,"a":2,"n":"Error","t":8,"pi":[{"n":"lib","pt":$n[0].String,"ps":0}],"sn":"Error","rt":$n[0].Void,"p":[$n[0].String]},{"ov":true,"a":2,"n":"PrepareDependenciesList","t":8,"sn":"PrepareDependenciesList","rt":$n[0].Void},{"ov":true,"a":2,"n":"Success","t":8,"pi":[{"n":"lib","pt":$n[0].String,"ps":0}],"sn":"Success","rt":$n[0].Void,"p":[$n[0].String]}]}; }, $n);
    $m("Kernel.Dependecies.EnsureLibrariesInstalledCorrectly_func", function () { return {"att":1048576,"a":4,"m":[{"a":2,"n":".ctor","t":1,"sn":"ctor"},{"v":true,"a":2,"n":"CheckifLibraryInstalled","t":8,"pi":[{"n":"lib","pt":$n[0].String,"ps":0}],"sn":"CheckifLibraryInstalled","rt":Function,"p":[$n[0].String]},{"v":true,"a":2,"n":"Error","t":8,"pi":[{"n":"lib","pt":$n[0].String,"ps":0}],"sn":"Error","rt":$n[0].Void,"p":[$n[0].String]},{"ov":true,"a":2,"n":"Execute","t":8,"sn":"Execute","rt":$n[0].Void},{"v":true,"a":2,"n":"PrepareDependenciesList","t":8,"sn":"PrepareDependenciesList","rt":$n[0].Void},{"v":true,"a":2,"n":"Success","t":8,"pi":[{"n":"lib","pt":$n[0].String,"ps":0}],"sn":"Success","rt":$n[0].Void,"p":[$n[0].String]},{"a":2,"n":"dependencies","t":4,"rt":$n[3].List$1(System.String),"sn":"dependencies"}]}; }, $n);
    $m("Kernel.Data.popupNotificationConst", function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"Error","is":true,"t":4,"rt":$n[0].String,"sn":"Error"},{"a":2,"n":"Sucess","is":true,"t":4,"rt":$n[0].String,"sn":"Sucess"}]}; }, $n);
    $m("Kernel.Attributes.TestedAttribute", function () { return {"att":1048577,"a":2,"m":[{"a":2,"n":".ctor","t":1,"p":[$n[0].String],"pi":[{"n":"msg","dv":"","o":true,"pt":$n[0].String,"ps":0}],"sn":"ctor"}]}; }, $n);
    $m("Kernel.Attributes.EventHandlerAttribute", function () { return {"att":1048577,"a":2,"m":[{"a":2,"n":".ctor","t":1,"p":[$n[0].String],"pi":[{"n":"msg","dv":"","o":true,"pt":$n[0].String,"ps":0}],"sn":"ctor"}]}; }, $n);
    $m("CDesktopWallper.ISerializer$1", function (TOutput) { return {"att":161,"a":2,"m":[{"ab":true,"a":2,"n":"DeserializeObject","t":8,"pi":[{"n":"value","pt":TOutput,"ps":0}],"tpc":1,"tprm":["T"],"sn":"CDesktopWallper$ISerializer$1$" + Bridge.getTypeAlias(TOutput) + "$DeserializeObject","rt":System.Object,"p":[TOutput]},{"ab":true,"a":2,"n":"LoadFile","t":8,"pi":[{"n":"file","pt":$n[0].String,"ps":0}],"sn":"CDesktopWallper$ISerializer$1$" + Bridge.getTypeAlias(TOutput) + "$LoadFile","rt":TOutput,"p":[$n[0].String]},{"ab":true,"a":2,"n":"SaveFile","t":8,"pi":[{"n":"output","pt":TOutput,"ps":0},{"n":"file","pt":$n[0].String,"ps":1}],"sn":"CDesktopWallper$ISerializer$1$" + Bridge.getTypeAlias(TOutput) + "$SaveFile","rt":$n[0].Void,"p":[TOutput,$n[0].String]},{"ab":true,"a":2,"n":"Serialize","t":8,"pi":[{"n":"value","pt":System.Object,"ps":0}],"tpc":1,"tprm":["T"],"sn":"CDesktopWallper$ISerializer$1$" + Bridge.getTypeAlias(TOutput) + "$Serialize","rt":TOutput,"p":[System.Object]}]}; }, $n);
    $m("CDesktopWallper.IClientSetting", function () { return {"att":161,"a":2,"m":[{"ab":true,"a":2,"n":"Load","t":8,"sn":"CDesktopWallper$IClientSetting$Load","rt":$n[0].Void},{"ab":true,"a":2,"n":"Save","t":8,"sn":"CDesktopWallper$IClientSetting$Save","rt":$n[0].Void},{"ab":true,"a":2,"n":"Data","t":16,"rt":$n[4].ClientSettingData,"g":{"ab":true,"a":2,"n":"get_Data","t":8,"rt":$n[4].ClientSettingData,"fg":"CDesktopWallper$IClientSetting$Data"},"s":{"ab":true,"a":2,"n":"set_Data","t":8,"p":[$n[4].ClientSettingData],"rt":$n[0].Void,"fs":"CDesktopWallper$IClientSetting$Data"},"fn":"CDesktopWallper$IClientSetting$Data"}]}; }, $n);
    $m("CDesktopWallper.IClientSettingData", function () { return {"att":161,"a":2,"m":[{"ab":true,"a":2,"n":"AutoWallper","t":16,"rt":$n[0].Boolean,"g":{"ab":true,"a":2,"n":"get_AutoWallper","t":8,"rt":$n[0].Boolean,"fg":"CDesktopWallper$IClientSettingData$AutoWallper","box":function ($v) { return Bridge.box($v, System.Boolean, System.Boolean.toString);}},"s":{"ab":true,"a":2,"n":"set_AutoWallper","t":8,"p":[$n[0].Boolean],"rt":$n[0].Void,"fs":"CDesktopWallper$IClientSettingData$AutoWallper"},"fn":"CDesktopWallper$IClientSettingData$AutoWallper"},{"ab":true,"a":2,"n":"Keywords","t":16,"rt":$n[3].List$1(System.String),"g":{"ab":true,"a":2,"n":"get_Keywords","t":8,"rt":$n[3].List$1(System.String),"fg":"CDesktopWallper$IClientSettingData$Keywords"},"s":{"ab":true,"a":2,"n":"set_Keywords","t":8,"p":[$n[3].List$1(System.String)],"rt":$n[0].Void,"fs":"CDesktopWallper$IClientSettingData$Keywords"},"fn":"CDesktopWallper$IClientSettingData$Keywords"},{"ab":true,"a":2,"n":"Locale","t":16,"rt":$n[0].String,"g":{"ab":true,"a":2,"n":"get_Locale","t":8,"rt":$n[0].String,"fg":"CDesktopWallper$IClientSettingData$Locale"},"s":{"ab":true,"a":2,"n":"set_Locale","t":8,"p":[$n[0].String],"rt":$n[0].Void,"fs":"CDesktopWallper$IClientSettingData$Locale"},"fn":"CDesktopWallper$IClientSettingData$Locale"},{"ab":true,"a":2,"n":"UrlSubscriptions","t":16,"rt":$n[3].List$1(System.String),"g":{"ab":true,"a":2,"n":"get_UrlSubscriptions","t":8,"rt":$n[3].List$1(System.String),"fg":"CDesktopWallper$IClientSettingData$UrlSubscriptions"},"s":{"ab":true,"a":2,"n":"set_UrlSubscriptions","t":8,"p":[$n[3].List$1(System.String)],"rt":$n[0].Void,"fs":"CDesktopWallper$IClientSettingData$UrlSubscriptions"},"fn":"CDesktopWallper$IClientSettingData$UrlSubscriptions"},{"ab":true,"a":2,"n":"WallerSource","t":16,"rt":$n[0].String,"g":{"ab":true,"a":2,"n":"get_WallerSource","t":8,"rt":$n[0].String,"fg":"CDesktopWallper$IClientSettingData$WallerSource"},"s":{"ab":true,"a":2,"n":"set_WallerSource","t":8,"p":[$n[0].String],"rt":$n[0].Void,"fs":"CDesktopWallper$IClientSettingData$WallerSource"},"fn":"CDesktopWallper$IClientSettingData$WallerSource"},{"ab":true,"a":2,"n":"Wallpers","t":16,"rt":$n[3].List$1(CDesktopWallper.WallperDescription),"g":{"ab":true,"a":2,"n":"get_Wallpers","t":8,"rt":$n[3].List$1(CDesktopWallper.WallperDescription),"fg":"CDesktopWallper$IClientSettingData$Wallpers"},"s":{"ab":true,"a":2,"n":"set_Wallpers","t":8,"p":[$n[3].List$1(CDesktopWallper.WallperDescription)],"rt":$n[0].Void,"fs":"CDesktopWallper$IClientSettingData$Wallpers"},"fn":"CDesktopWallper$IClientSettingData$Wallpers"}]}; }, $n);
    $m("CDesktopWallper.ClientSetting", function () { return {"att":1048577,"a":2,"m":[{"a":2,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"Load","t":8,"sn":"Load","rt":$n[0].Void},{"a":2,"n":"Save","t":8,"sn":"Save","rt":$n[0].Void},{"a":2,"n":"Set","is":true,"t":8,"pi":[{"n":"name","pt":$n[0].String,"ps":0},{"n":"value","pt":$n[0].Object,"ps":1}],"sn":"Set","rt":$n[0].Void,"p":[$n[0].String,$n[0].Object]},{"a":2,"n":"Data","t":16,"rt":$n[4].ClientSettingData,"g":{"a":2,"n":"get_Data","t":8,"rt":$n[4].ClientSettingData,"fg":"Data"},"s":{"a":2,"n":"set_Data","t":8,"p":[$n[4].ClientSettingData],"rt":$n[0].Void,"fs":"Data"},"fn":"Data"},{"a":2,"n":"OnComplete","t":4,"rt":Function,"sn":"OnComplete"},{"a":2,"n":"Socket","is":true,"t":4,"rt":WebSocket,"sn":"Socket"}]}; }, $n);
    $m("CDesktopWallper.SettingCommand", function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"Name","t":4,"rt":$n[0].String,"sn":"Name"},{"a":2,"n":"Value","t":4,"rt":$n[0].Object,"sn":"Value"}]}; }, $n);
    $m("CDesktopWallper.ClientSettingData", function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"AutoWallper","t":16,"rt":$n[0].Boolean,"g":{"a":2,"n":"get_AutoWallper","t":8,"rt":$n[0].Boolean,"fg":"AutoWallper","box":function ($v) { return Bridge.box($v, System.Boolean, System.Boolean.toString);}},"s":{"a":2,"n":"set_AutoWallper","t":8,"p":[$n[0].Boolean],"rt":$n[0].Void,"fs":"AutoWallper"},"fn":"AutoWallper"},{"a":2,"n":"Keywords","t":16,"rt":$n[3].List$1(System.String),"g":{"a":2,"n":"get_Keywords","t":8,"rt":$n[3].List$1(System.String),"fg":"Keywords"},"s":{"a":2,"n":"set_Keywords","t":8,"p":[$n[3].List$1(System.String)],"rt":$n[0].Void,"fs":"Keywords"},"fn":"Keywords"},{"a":2,"n":"Locale","t":16,"rt":$n[0].String,"g":{"a":2,"n":"get_Locale","t":8,"rt":$n[0].String,"fg":"Locale"},"s":{"a":2,"n":"set_Locale","t":8,"p":[$n[0].String],"rt":$n[0].Void,"fs":"Locale"},"fn":"Locale"},{"a":2,"n":"UrlSubscriptions","t":16,"rt":$n[3].List$1(System.String),"g":{"a":2,"n":"get_UrlSubscriptions","t":8,"rt":$n[3].List$1(System.String),"fg":"UrlSubscriptions"},"s":{"a":2,"n":"set_UrlSubscriptions","t":8,"p":[$n[3].List$1(System.String)],"rt":$n[0].Void,"fs":"UrlSubscriptions"},"fn":"UrlSubscriptions"},{"a":2,"n":"WallerSource","t":16,"rt":$n[0].String,"g":{"a":2,"n":"get_WallerSource","t":8,"rt":$n[0].String,"fg":"WallerSource"},"s":{"a":2,"n":"set_WallerSource","t":8,"p":[$n[0].String],"rt":$n[0].Void,"fs":"WallerSource"},"fn":"WallerSource"},{"a":2,"n":"Wallpers","t":16,"rt":$n[3].List$1(CDesktopWallper.WallperDescription),"g":{"a":2,"n":"get_Wallpers","t":8,"rt":$n[3].List$1(CDesktopWallper.WallperDescription),"fg":"Wallpers"},"s":{"a":2,"n":"set_Wallpers","t":8,"p":[$n[3].List$1(CDesktopWallper.WallperDescription)],"rt":$n[0].Void,"fs":"Wallpers"},"fn":"Wallpers"},{"a":1,"n":"_AutoWallper","t":4,"rt":$n[0].Boolean,"sn":"_AutoWallper","box":function ($v) { return Bridge.box($v, System.Boolean, System.Boolean.toString);}}]}; }, $n);
    $m("CDesktopWallper.Size", function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"v":true,"a":2,"n":"Height","t":16,"rt":$n[0].Int32,"g":{"v":true,"a":2,"n":"get_Height","t":8,"rt":$n[0].Int32,"fg":"Height","box":function ($v) { return Bridge.box($v, System.Int32);}},"s":{"v":true,"a":2,"n":"set_Height","t":8,"p":[$n[0].Int32],"rt":$n[0].Void,"fs":"Height"},"fn":"Height"},{"v":true,"a":2,"n":"Width","t":16,"rt":$n[0].Int32,"g":{"v":true,"a":2,"n":"get_Width","t":8,"rt":$n[0].Int32,"fg":"Width","box":function ($v) { return Bridge.box($v, System.Int32);}},"s":{"v":true,"a":2,"n":"set_Width","t":8,"p":[$n[0].Int32],"rt":$n[0].Void,"fs":"Width"},"fn":"Width"}]}; }, $n);
    $m("CDesktopWallper.WallperDescription", function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"v":true,"a":2,"n":"LocalPath","t":16,"rt":$n[0].String,"g":{"v":true,"a":2,"n":"get_LocalPath","t":8,"rt":$n[0].String,"fg":"LocalPath"},"s":{"v":true,"a":2,"n":"set_LocalPath","t":8,"p":[$n[0].String],"rt":$n[0].Void,"fs":"LocalPath"},"fn":"LocalPath"},{"v":true,"a":2,"n":"Size","t":16,"rt":$n[4].Size,"g":{"v":true,"a":2,"n":"get_Size","t":8,"rt":$n[4].Size,"fg":"Size"},"s":{"v":true,"a":2,"n":"set_Size","t":8,"p":[$n[4].Size],"rt":$n[0].Void,"fs":"Size"},"fn":"Size"},{"v":true,"a":2,"n":"Tags","t":16,"rt":$n[0].String,"g":{"v":true,"a":2,"n":"get_Tags","t":8,"rt":$n[0].String,"fg":"Tags"},"s":{"v":true,"a":2,"n":"set_Tags","t":8,"p":[$n[0].String],"rt":$n[0].Void,"fs":"Tags"},"fn":"Tags"},{"a":2,"n":"ThumbUrl","t":16,"rt":$n[0].String,"g":{"a":2,"n":"get_ThumbUrl","t":8,"rt":$n[0].String,"fg":"ThumbUrl"},"s":{"a":2,"n":"set_ThumbUrl","t":8,"p":[$n[0].String],"rt":$n[0].Void,"fs":"ThumbUrl"},"fn":"ThumbUrl"},{"v":true,"a":2,"n":"Url","t":16,"rt":$n[0].String,"g":{"v":true,"a":2,"n":"get_Url","t":8,"rt":$n[0].String,"fg":"Url"},"s":{"v":true,"a":2,"n":"set_Url","t":8,"p":[$n[0].String],"rt":$n[0].Void,"fs":"Url"},"fn":"Url"}]}; }, $n);
    $m("ClientScript.App", function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"Append","is":true,"t":8,"pi":[{"n":"html","pt":$n[0].String,"ps":0}],"sn":"Append","rt":$n[0].Void,"p":[$n[0].String]},{"a":2,"n":"Append","is":true,"t":8,"pi":[{"n":"element","pt":System.Object,"ps":0}],"tpc":1,"tprm":["T"],"sn":"Append$1","rt":$n[0].Void,"p":[System.Object]},{"a":2,"n":"ExecuteRequestModule","is":true,"t":8,"sn":"ExecuteRequestModule","rt":$n[0].Void},{"a":2,"n":"GetAppMainWindows","is":true,"t":8,"sn":"GetAppMainWindows","rt":Element},{"a":2,"n":"GetAppTitle","is":true,"t":8,"sn":"GetAppTitle","rt":Bridge.virtualc("HTMLCollectionOf")},{"a":2,"n":"GetBreadcrumb","is":true,"t":8,"sn":"GetBreadcrumb","rt":Element},{"a":2,"n":"GetCurrentModule","is":true,"t":8,"sn":"GetCurrentModule","rt":$n[0].String},{"a":2,"n":"LazyImageLoad","is":true,"t":8,"sn":"LazyImageLoad","rt":$n[0].Void},{"a":2,"n":"Main","is":true,"t":8,"sn":"Main","rt":$n[0].Void},{"a":2,"n":"OnError","is":true,"t":8,"sn":"OnError","rt":$n[0].Void},{"a":2,"n":"PushMessage","is":true,"t":8,"pi":[{"n":"message","pt":$n[0].String,"ps":0}],"sn":"PushMessage","rt":$n[0].Void,"p":[$n[0].String]},{"a":2,"n":"RequireJS","is":true,"t":8,"pi":[{"n":"url","pt":$n[0].String,"ps":0}],"sn":"RequireJS","rt":$n[0].Void,"p":[$n[0].String]},{"a":2,"n":"SetBreadcrumb","is":true,"t":8,"pi":[{"n":"directions","pt":$n[3].List$1(System.String),"ps":0}],"sn":"SetBreadcrumb","rt":$n[0].Void,"p":[$n[3].List$1(System.String)]},{"a":2,"n":"SetBreadcrumb","is":true,"t":8,"pi":[{"n":"directions","ip":true,"pt":$n[0].Array.type(System.String),"ps":0}],"sn":"SetBreadcrumb$1","rt":$n[0].Void,"p":[$n[0].Array.type(System.String)]},{"a":2,"n":"SetTitle","is":true,"t":8,"pi":[{"n":"s","pt":$n[0].String,"ps":0}],"sn":"SetTitle","rt":$n[0].Void,"p":[$n[0].String]}]}; }, $n);
    $m("ClientScript.ContextMenu", function () { return {"att":1048577,"a":2,"m":[{"a":2,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"Disable","is":true,"t":8,"sn":"Disable","rt":$n[0].Void}]}; }, $n);
    $m("ClientScript.InternetWallperWebViewWSClient", function () { return {"att":1048577,"a":2,"m":[{"a":2,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"Loading","t":8,"sn":"Loading","rt":HTMLDivElement},{"a":2,"n":"ParseWallpers","t":8,"pi":[{"n":"message","pt":MessageEvent,"ps":0}],"sn":"ParseWallpers","rt":$n[0].Void,"p":[MessageEvent]},{"a":2,"n":"SetWallper","is":true,"t":8,"pi":[{"n":"element","pt":HTMLButtonElement,"ps":0}],"sn":"SetWallper","rt":$n[0].Void,"p":[HTMLButtonElement]},{"a":2,"n":"Socket","is":true,"t":4,"rt":WebSocket,"sn":"Socket"}]}; }, $n);
    $m("ClientScript.LocalWallperWebViewWSClient", function () { return {"att":1048577,"a":2,"m":[{"a":2,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"Loading","t":8,"sn":"Loading","rt":HTMLDivElement},{"a":2,"n":"ParseWallpers","is":true,"t":8,"pi":[{"n":"wallpers","pt":$n[3].List$1(CDesktopWallper.WallperDescription),"ps":0}],"sn":"ParseWallpers","rt":$n[0].Void,"p":[$n[3].List$1(CDesktopWallper.WallperDescription)]},{"a":2,"n":"SetWallper","is":true,"t":8,"pi":[{"n":"element","pt":HTMLButtonElement,"ps":0}],"sn":"SetWallper","rt":$n[0].Void,"p":[HTMLButtonElement]},{"a":1,"n":"ViewPage","is":true,"t":8,"pi":[{"n":"page","pt":$n[0].Int32,"ps":0}],"sn":"ViewPage","rt":$n[0].Void,"p":[$n[0].Int32]},{"a":2,"n":"Socket","is":true,"t":4,"rt":WebSocket,"sn":"Socket"},{"a":2,"n":"currentPage","is":true,"t":4,"rt":$n[0].Int32,"sn":"currentPage","box":function ($v) { return Bridge.box($v, System.Int32);}}]}; }, $n);
    $m("ClientScript.ModulesWebViewWS", function () { return {"att":1048577,"a":2,"m":[{"a":2,"n":".ctor","t":1,"sn":"ctor"}]}; }, $n);
    $m("ClientScript.Path", function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"GetFileName","is":true,"t":8,"pi":[{"n":"filePath","pt":$n[0].String,"ps":0}],"sn":"GetFileName","rt":$n[0].String,"p":[$n[0].String]}]}; }, $n);
    $m("ClientScript.Resource", function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"ComponentUrl","t":8,"pi":[{"n":"name","pt":$n[0].String,"ps":0}],"sn":"ComponentUrl","rt":$n[0].String,"p":[$n[0].String]},{"a":2,"n":"WsAddress","t":8,"pi":[{"n":"name","pt":$n[0].String,"ps":0}],"sn":"WsAddress","rt":$n[0].String,"p":[$n[0].String]},{"a":2,"n":"Instance","is":true,"t":16,"rt":$n[5].Resource,"g":{"a":2,"n":"get_Instance","t":8,"rt":$n[5].Resource,"fg":"Instance","is":true},"fn":"Instance"},{"a":2,"n":"InternetWallperWebViewWS","t":16,"rt":$n[0].String,"g":{"a":2,"n":"get_InternetWallperWebViewWS","t":8,"rt":$n[0].String,"fg":"InternetWallperWebViewWS"},"fn":"InternetWallperWebViewWS"},{"a":2,"n":"LocalWallperWebViewWS","t":16,"rt":$n[0].String,"g":{"a":2,"n":"get_LocalWallperWebViewWS","t":8,"rt":$n[0].String,"fg":"LocalWallperWebViewWS"},"fn":"LocalWallperWebViewWS"},{"a":2,"n":"SettingWebViewWS","t":16,"rt":$n[0].String,"g":{"a":2,"n":"get_SettingWebViewWS","t":8,"rt":$n[0].String,"fg":"SettingWebViewWS"},"fn":"SettingWebViewWS"}]}; }, $n);
    $m("ClientScript.SettingWebViewWSClient", function () { return {"att":1048577,"a":2,"m":[{"a":2,"n":".ctor","t":1,"sn":"ctor"},{"a":1,"n":"BtnActiveOnClick","t":8,"sn":"BtnActiveOnClick","rt":$n[0].Void},{"a":2,"n":"LoadSettings","t":8,"pi":[{"n":"clientSetting","pt":$n[4].ClientSetting,"ps":0}],"sn":"LoadSettings","rt":$n[0].Void,"p":[$n[4].ClientSetting]},{"a":2,"n":"Start","is":true,"t":8,"sn":"Start","rt":$n[0].Void},{"a":2,"n":"Stop","is":true,"t":8,"sn":"Stop","rt":$n[0].Void},{"a":2,"n":"Socket","is":true,"t":4,"rt":WebSocket,"sn":"Socket"}]}; }, $n);
    $m("ClientScript.Component", function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"GET","is":true,"t":8,"pi":[{"n":"name","pt":$n[0].String,"ps":0}],"sn":"GET","rt":$n[1].Task$1(System.String),"p":[$n[0].String]}]}; }, $n);
    $m("ClientScript.WallperPreviewCard", function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"ov":true,"a":2,"n":"ToString","t":8,"sn":"toString","rt":$n[0].String},{"a":2,"n":"Status","t":16,"rt":$n[0].String,"g":{"a":2,"n":"get_Status","t":8,"rt":$n[0].String,"fg":"Status"},"s":{"a":2,"n":"set_Status","t":8,"p":[$n[0].String],"rt":$n[0].Void,"fs":"Status"},"fn":"Status"},{"a":2,"n":"Thumb","t":16,"rt":$n[0].String,"g":{"a":2,"n":"get_Thumb","t":8,"rt":$n[0].String,"fg":"Thumb"},"s":{"a":2,"n":"set_Thumb","t":8,"p":[$n[0].String],"rt":$n[0].Void,"fs":"Thumb"},"fn":"Thumb"},{"a":2,"n":"Title","t":16,"rt":$n[0].String,"g":{"a":2,"n":"get_Title","t":8,"rt":$n[0].String,"fg":"Title"},"s":{"a":2,"n":"set_Title","t":8,"p":[$n[0].String],"rt":$n[0].Void,"fs":"Title"},"fn":"Title"},{"a":2,"n":"Wallper","t":16,"rt":$n[0].String,"g":{"a":2,"n":"get_Wallper","t":8,"rt":$n[0].String,"fg":"Wallper"},"s":{"a":2,"n":"set_Wallper","t":8,"p":[$n[0].String],"rt":$n[0].Void,"fs":"Wallper"},"fn":"Wallper"}]}; }, $n);
    $m("ClientScript.WallperPage", function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"ov":true,"a":2,"n":"ToString","t":8,"sn":"toString","rt":$n[0].String}]}; }, $n);
    $m("ClientScript.Exensions.ObjectExt", function () { return {"att":1048961,"a":2,"s":true,"m":[{"a":2,"n":"GetField","is":true,"t":8,"pi":[{"n":"obj","pt":$n[0].Object,"ps":0},{"n":"name","pt":$n[0].String,"ps":1}],"tpc":1,"tprm":["T"],"sn":"GetField","rt":System.Object,"p":[$n[0].Object,$n[0].String]}]}; }, $n);
    $m("Shared.WsCommand", function () { return {"att":1048577,"a":2,"m":[{"a":2,"isSynthetic":true,"n":".ctor","t":1,"sn":"ctor"},{"a":2,"n":"Command","t":16,"rt":$n[0].String,"g":{"a":2,"n":"get_Command","t":8,"rt":$n[0].String,"fg":"Command"},"s":{"a":2,"n":"set_Command","t":8,"p":[$n[0].String],"rt":$n[0].Void,"fs":"Command"},"fn":"Command"},{"a":2,"n":"JsonData","t":16,"rt":$n[0].String,"g":{"a":2,"n":"get_JsonData","t":8,"rt":$n[0].String,"fg":"JsonData"},"s":{"a":2,"n":"set_JsonData","t":8,"p":[$n[0].String],"rt":$n[0].Void,"fs":"JsonData"},"fn":"JsonData"}]}; }, $n);
});
