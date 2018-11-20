/**
 * CDesktopWallper - Beautify your desktop
 * @version 1.0.0.0
 * @author Trần Mạnh Cường
 * @copyright Copyright ©  Trần Mạnh Cường 2018
 * @compiler Bridge.NET 17.3.0
 */
Bridge.assembly("ClientScript", function ($asm, globals) {
    "use strict";

    Bridge.define("CDesktopWallper.IClientSetting", {
        $kind: "interface"
    });

    Bridge.define("CDesktopWallper.IClientSettingData", {
        $kind: "interface"
    });

    Bridge.definei("CDesktopWallper.ISerializer$1", function (TOutput) { return {
        $kind: "interface"
    }; });

    Bridge.define("CDesktopWallper.SettingCommand", {
        fields: {
            Name: null,
            Value: null
        }
    });

    Bridge.define("CDesktopWallper.Size", {
        fields: {
            Width: 0,
            Height: 0
        }
    });

    Bridge.define("CDesktopWallper.WallperDescription", {
        fields: {
            Url: null,
            ThumbUrl: null,
            Size: null,
            LocalPath: null,
            Tags: null
        }
    });

    Bridge.define("ClientScript.App", {
        statics: {
            ctors: {
                init: function () {
                    Bridge.ready(this.ExecuteRequestModule);
                    Bridge.ready(this.Main);
                    Bridge.ready(this.OnError);
                }
            },
            methods: {
                GetAppMainWindows: function () {
                    return System.Linq.Enumerable.from(document.getElementsByClassName("content mt-3")).singleOrDefault(null, null);
                },
                GetBreadcrumb: function () {
                    return System.Linq.Enumerable.from(document.getElementsByClassName("breadcrumb text-right")).singleOrDefault(null, null);
                },
                GetAppTitle: function () {
                    return document.getElementsByClassName("page-title");
                },
                GetCurrentModule: function () {
                    switch (window.location.pathname) {
                        case "/local-wallpers.html": 
                            return "LocalWallperWebViewWS";
                        case "/tables-data.html": 
                            return "InternetWallperWebViewWS";
                        case "": 
                        case "/": 
                        case "/index.html": 
                            return "Index";
                        case "/auto-change-wallper.html": 
                            return "TaskSchedulerWebViewWS";
                        case "/modules.html": 
                            return "ModulesWebViewWS";
                        default: 
                            return "unknown";
                    }
                },
                Append: function (html) {
                    var content = ClientScript.App.GetAppMainWindows();
                    content.innerHTML = (content.innerHTML || "") + (html || "");
                },
                Append$1: function (T, element) {
                    var content = ClientScript.App.GetAppMainWindows();
                    content.appendChild(element);
                },
                SetBreadcrumb: function (directions) {
                    var $t, $t1;
                    var Br = ClientScript.App.GetBreadcrumb();
                    Br.innerHTML = "";
                    $t = Bridge.getEnumerator(directions);
                    try {
                        while ($t.moveNext()) {
                            var direction = $t.Current;
                            var li = ($t1 = document.createElement("li"), $t1.innerHTML = direction, $t1.className = "breadcrumb-item", $t1);

                            if (Bridge.referenceEquals(direction, System.Linq.Enumerable.from(directions).last())) {
                                li.className = (li.className || "") + " active";
                            }

                            Br.appendChild(li);
                        }
                    } finally {
                        if (Bridge.is($t, System.IDisposable)) {
                            $t.System$IDisposable$Dispose();
                        }
                    }
                },
                SetBreadcrumb$1: function (directions) {
                    if (directions === void 0) { directions = []; }
                    ClientScript.App.SetBreadcrumb(System.Linq.Enumerable.from(directions).toList(System.String));
                },
                SetTitle: function (s) {
                    var page_title = ClientScript.App.GetAppTitle();
                    page_title[0].children[0].innerHTML = s;

                },
                /**
                 * Nạp module javascript từ url
                 *
                 * @static
                 * @public
                 * @this ClientScript.App
                 * @memberof ClientScript.App
                 * @param   {string}    url
                 * @return  {void}
                 */
                RequireJS: function (url) {
                    var script = document.createElement("script");
                    script.addEventListener("load", function (e) {
                        console.log(System.String.format("Module {0} đã nạp xong", [url]));
                    });
                    script.src = url;
                    script.async = true;
                    document.head.appendChild(script);
                },
                ExecuteRequestModule: function () {
                    var $t;
                    try {

                        var currentModule = ClientScript.App.GetCurrentModule();
                        switch (currentModule) {
                            case "Index": 
                                var ads = ($t = new Kernel.AjaxTask(), $t.Method = "GET", $t.Url = "/Templates/ad.htm", $t.Async = true, $t);
                                ads.Execute().getAwaiter().continueWith(function () {
                                    ClientScript.App.Append(ads.AjaxResult);
                                });
                                break;
                            case "LocalWallperWebViewWS": 
                                new ClientScript.LocalWallperWebViewWSClient();
                                break;
                            case "InternetWallperWebViewWS": 
                                new ClientScript.InternetWallperWebViewWSClient();
                                break;
                            case "TaskSchedulerWebViewWS": 
                                new ClientScript.SettingWebViewWSClient();
                                break;
                            case "ModulesWebViewWS": 
                                new ClientScript.ModulesWebViewWS();
                                break;
                            default: 
                                ClientScript.App.PushMessage("Module này không sử dụng được");
                                break;
                        }
                    } catch (err) {
                        err = System.Exception.create(err);
                        document.writeln("Lỗi khi khởi động ứng dụng : " + (err.Message || ""));
                    }


                },
                Main: function () { },
                LazyImageLoad: function () {
                    jQuery(".lazy").Lazy({ scrollDirection: "vertical", effect: "fadeIn", visibleOnly: true });
                },
                OnError: function () {
                    window.addEventListener("error", function (e) {
                        alert("Không tải được resouce");
                    });
                },
                PushMessage: function (message) {
                    Push.create(message);
                }
            }
        },
        $entryPoint: true
    });

    Bridge.define("ClientScript.Component", {
        statics: {
            methods: {
                GET: function (name) {
                    var $step = 0,
                        $task1, 
                        $taskResult1, 
                        $jumpFromFinally, 
                        $tcs = new System.Threading.Tasks.TaskCompletionSource(), 
                        $returnValue, 
                        url, 
                        ajax, 
                        $t, 
                        $async_e, 
                        $asyncBody = Bridge.fn.bind(this, function () {
                            try {
                                for (;;) {
                                    $step = System.Array.min([0,1], $step);
                                    switch ($step) {
                                        case 0: {
                                            url = ClientScript.Resource.Instance.ComponentUrl(name);
                                            ajax = ($t = new Kernel.AjaxTask(), $t.Method = "GET", $t.Url = url, $t.Async = true, $t);

                                            $task1 = ajax.Execute();
                                            $step = 1;
                                            $task1.continueWith($asyncBody);
                                            return;
                                        }
                                        case 1: {
                                            $taskResult1 = $task1.getAwaitedResult();
                                            $tcs.setResult($taskResult1);
                                            return;
                                        }
                                        default: {
                                            $tcs.setResult(null);
                                            return;
                                        }
                                    }
                                }
                            } catch($async_e1) {
                                $async_e = System.Exception.create($async_e1);
                                $tcs.setException($async_e);
                            }
                        }, arguments);

                    $asyncBody();
                    return $tcs.task;
                }
            }
        }
    });

    Bridge.define("ClientScript.ContextMenu", {
        statics: {
            methods: {
                Disable: function () {
                    window.addEventListener("contextmenu", function (e) {
                        e.preventDefault();
                    });
                }
            }
        },
        ctors: {
            ctor: function () {
                this.$initialize();

            }
        }
    });

    Bridge.define("ClientScript.Exensions.ObjectExt", {
        statics: {
            methods: {
                GetField: function (T, obj, name) {
                    return eval("obj[name]");
                }
            }
        }
    });

    Bridge.define("ClientScript.InternetWallperWebViewWSClient", {
        statics: {
            fields: {
                Socket: null
            },
            ctors: {
                init: function () {
                    this.Socket = new WebSocket(ClientScript.Resource.Instance.InternetWallperWebViewWS);
                }
            },
            methods: {
                SetWallper: function (element) {
                    var $t;
                    var src = "";
                    var cardbody = element.parentNode.parentNode;
                    src = cardbody.lastChild.getAttribute("data-src");
                    var setWallperCmd = ($t = new Shared.WsCommand(), $t.Command = "SetWallper", $t.JsonData = src, $t);

                    ClientScript.InternetWallperWebViewWSClient.Socket.send(Json.Stringify(setWallperCmd));
                }
            }
        },
        ctors: {
            ctor: function () {
                this.$initialize();
                ClientScript.App.SetTitle("Danh sách ảnh lưu trên mạng");
                ClientScript.App.SetBreadcrumb$1(["Ảnh", "Trên mạng"]);
                ClientScript.App.Append$1(Bridge.global.HTMLDivElement, this.Loading());
                ClientScript.InternetWallperWebViewWSClient.Socket.onopen = Bridge.fn.combine(ClientScript.InternetWallperWebViewWSClient.Socket.onopen, function (open) {
                    var $t;
                    var ListAll = ($t = new Shared.WsCommand(), $t.Command = "ListAll", $t.JsonData = "", $t);
                    ClientScript.InternetWallperWebViewWSClient.Socket.send(Json.Stringify(ListAll));
                });

                ClientScript.InternetWallperWebViewWSClient.Socket.onmessage = Bridge.fn.combine(ClientScript.InternetWallperWebViewWSClient.Socket.onmessage, Bridge.fn.bind(this, function (message) {
                    try {
                        var command = Json.Parse(message.data);
                        switch (command.Command) {
                            case "SetListWallperCommand": 
                                this.ParseWallpers(message);
                                break;
                            default: 
                                break;
                        }

                    } catch ($e1) {
                        $e1 = System.Exception.create($e1);
                        console.log(message.data);
                    }


                }));
                ClientScript.InternetWallperWebViewWSClient.Socket.onerror = Bridge.fn.combine(ClientScript.InternetWallperWebViewWSClient.Socket.onerror, function (error) {
                    System.Console.WriteLine(error);
                });
            }
        },
        methods: {
            Loading: function () {
                var $t, $t1, $t2;
                return ($t = document.createElement("div"), $t.className = "animated fadeIn", $t.innerHTML = ($t1 = document.createElement("div"), $t1.className = "row", $t1.id = "InternetWallperWebView", $t1.innerHTML = ($t2 = document.createElement("div"), $t2.className = "loader", $t2).outerHTML, $t1).outerHTML, $t);
            },
            ParseWallpers: function (message) {
                var $t, $t1;
                var command = Json.Parse(message.data);
                var wallpers = Json.Parse(command.JsonData);
                if (wallpers.Count === 0) {
                    alert("Không tìm thấy kết quả nào");
                }
                var page = new ClientScript.WallperPage();
                $t = Bridge.getEnumerator(wallpers);
                try {
                    while ($t.moveNext()) {
                        var wallper = $t.Current;
                        var wallperPreviewcard = ($t1 = new ClientScript.WallperPreviewCard(), $t1.Status = "internet", $t1.Title = "Hình nền", $t1.Wallper = wallper.Url, $t1.Thumb = wallper.ThumbUrl, $t1);
                        page.add(wallperPreviewcard);
                    }
                } finally {
                    if (Bridge.is($t, System.IDisposable)) {
                        $t.System$IDisposable$Dispose();
                    }
                }
                ;

                document.getElementById("InternetWallperWebView").innerHTML = page.toString();

                var setWallperButtons = document.getElementsByName("SetWallper");
                for (var i = 0; i < setWallperButtons.length; i++) {
                    var element = { v : setWallperButtons[i] };
                    setWallperButtons[i].onclick = (function ($me, element) {
                        return function (e) {
                            ClientScript.InternetWallperWebViewWSClient.SetWallper(element.v);
                        };
                    })(this, element);
                }
            }
        }
    });

    Bridge.define("ClientScript.LocalWallperWebViewWSClient", {
        statics: {
            fields: {
                Socket: null,
                currentPage: 0
            },
            ctors: {
                init: function () {
                    this.Socket = new WebSocket(ClientScript.Resource.Instance.LocalWallperWebViewWS);
                    this.currentPage = 1;
                }
            },
            methods: {
                ViewPage: function (page) {
                    var $t;
                    System.Console.WriteLine(System.String.format("Đang hiển thị trang {0}", [page]));
                    var ListAll = ($t = new Shared.WsCommand(), $t.Command = "ListAll", $t.JsonData = Bridge.toString(page), $t);
                    ClientScript.LocalWallperWebViewWSClient.Socket.send(Json.Stringify(ListAll));
                },
                SetWallper: function (element) {
                    var $t;

                    var src = "";
                    var cardbody = element.parentNode.parentNode;
                    src = cardbody.lastChild.getAttribute("data-src");
                    var setWallperCmd = ($t = new Shared.WsCommand(), $t.Command = "SetWallper", $t.JsonData = src, $t);

                    ClientScript.LocalWallperWebViewWSClient.Socket.send(Json.Stringify(setWallperCmd));
                },
                ParseWallpers: function (wallpers) {
                    var $t, $t1;
                    var page = new ClientScript.WallperPage();
                    $t = Bridge.getEnumerator(wallpers);
                    try {
                        while ($t.moveNext()) {
                            var wallper = $t.Current;
                            var wallperPreviewcard = ($t1 = new ClientScript.WallperPreviewCard(), $t1.Status = "Đã tải", $t1.Title = wallper.LocalPath, $t1.Wallper = "wallpers/" + (wallper.LocalPath || ""), $t1);
                            page.add(wallperPreviewcard);
                        }
                    } finally {
                        if (Bridge.is($t, System.IDisposable)) {
                            $t.System$IDisposable$Dispose();
                        }
                    }
                    ;

                    document.getElementById("LocalWallperWebView").innerHTML = page.toString();
                    var setWallperButtons = document.getElementsByName("SetWallper");
                    for (var i = 0; i < setWallperButtons.length; i++) {
                        var element = { v : setWallperButtons[i] };
                        setWallperButtons[i].onclick = (function ($me, element) {
                            return function (e) {
                                ClientScript.LocalWallperWebViewWSClient.SetWallper(element.v);
                            };
                        })(this, element);
                    }
                }
            }
        },
        ctors: {
            ctor: function () {
                this.$initialize();
                ClientScript.App.SetTitle("Danh sách ảnh lưu trên máy");
                ClientScript.App.SetBreadcrumb$1(["Ảnh", "Trên máy"]);
                ClientScript.App.Append$1(Bridge.global.HTMLDivElement, this.Loading());
                ClientScript.LocalWallperWebViewWSClient.Socket.onopen = Bridge.fn.combine(ClientScript.LocalWallperWebViewWSClient.Socket.onopen, function (open) {
                    ClientScript.LocalWallperWebViewWSClient.ViewPage(ClientScript.LocalWallperWebViewWSClient.currentPage);
                });

                ClientScript.LocalWallperWebViewWSClient.Socket.onmessage = Bridge.fn.combine(ClientScript.LocalWallperWebViewWSClient.Socket.onmessage, function (message) {
                    try {
                        var command = Json.Parse(message.data);
                        switch (command.Command) {
                            case "SetListWallperCommand": 
                                var wallpers = Json.Parse(command.JsonData);
                                if (System.Linq.Enumerable.from(wallpers).any()) {
                                    ClientScript.LocalWallperWebViewWSClient.ParseWallpers(wallpers);
                                } else {
                                    ClientScript.LocalWallperWebViewWSClient.currentPage = 0;
                                    System.Console.WriteLine(System.String.format("Không có trang {0}, đang quay về trang đầu", [ClientScript.LocalWallperWebViewWSClient.currentPage]));
                                }
                                break;
                            default: 
                                break;
                        }

                    } catch ($e1) {
                        $e1 = System.Exception.create($e1);
                        console.log(message.data);
                    }
                });

                ClientScript.LocalWallperWebViewWSClient.Socket.onerror = Bridge.fn.combine(ClientScript.LocalWallperWebViewWSClient.Socket.onerror, function (error) {
                    System.Console.WriteLine(error);
                });

                document.onscroll = Bridge.fn.combine(document.onscroll, function (evt) {
                    if ((window.innerHeight + window.pageYOffset) >= document.body.offsetHeight) {
                        ClientScript.LocalWallperWebViewWSClient.currentPage = ClientScript.LocalWallperWebViewWSClient.currentPage + 1;
                        ClientScript.LocalWallperWebViewWSClient.ViewPage(ClientScript.LocalWallperWebViewWSClient.currentPage);
                        window.scrollTo(0, 0);
                        Bridge.sleep(1000);
                    }

                    if ((window.innerHeight + window.pageYOffset) >= document.body.offsetHeight) {

                    }
                });
            }
        },
        methods: {
            Loading: function () {
                var $t, $t1, $t2;

                return ($t = document.createElement("div"), $t.className = "animated fadeIn", $t.innerHTML = ($t1 = document.createElement("div"), $t1.className = "row", $t1.id = "LocalWallperWebView", $t1.innerHTML = ($t2 = document.createElement("div"), $t2.className = "loader", $t2).outerHTML, $t1).outerHTML, $t);
            }
        }
    });

    Bridge.define("ClientScript.ModulesWebViewWS", {
        ctors: {
            ctor: function () {
                this.$initialize();
                ClientScript.App.SetTitle("Danh sách ứng dụng");
                ClientScript.App.SetBreadcrumb$1(["Kho tính năng", "Danh sách"]);
                ClientScript.App.Append("Đây là danh sách các ứng dụng của hệ thống");

            }
        }
    });

    Bridge.define("ClientScript.Path", {
        statics: {
            methods: {
                GetFileName: function (filePath) {
                    return "";
                }
            }
        }
    });

    Bridge.define("ClientScript.Resource", {
        statics: {
            props: {
                Instance: {
                    get: function () {
                        return new ClientScript.Resource();
                    }
                }
            }
        },
        props: {
            LocalWallperWebViewWS: {
                get: function () {
                    return this.WsAddress("LocalWallperWebViewWS");
                }
            },
            InternetWallperWebViewWS: {
                get: function () {
                    return this.WsAddress("InternetWallperWebViewWS");
                }
            },
            SettingWebViewWS: {
                get: function () {
                    return this.WsAddress("SettingWebViewWS");
                }
            }
        },
        methods: {
            WsAddress: function (name) {
                return System.String.format("ws://{0}:5000/{1}", window.location.hostname, name);
            },
            ComponentUrl: function (name) {
                return System.String.format("/Components/{0}.htm", [name]);
            }
        }
    });

    Bridge.define("ClientScript.SettingWebViewWSClient", {
        statics: {
            fields: {
                Socket: null
            },
            ctors: {
                init: function () {
                    this.Socket = new WebSocket(ClientScript.Resource.Instance.SettingWebViewWS);
                }
            },
            methods: {
                Start: function () {
                    var $t;
                    ClientScript.SettingWebViewWSClient.Socket.send(Json.Stringify(($t = new Shared.WsCommand(), $t.Command = "Start", $t)));
                },
                Stop: function () {
                    var $t;
                    ClientScript.SettingWebViewWSClient.Socket.send(Json.Stringify(($t = new Shared.WsCommand(), $t.Command = "Stop", $t)));
                }
            }
        },
        ctors: {
            ctor: function () {
                this.$initialize();
                ClientScript.App.SetTitle("Tự động chuyển hình nền");
                ClientScript.App.SetBreadcrumb$1(["Tính năng", "Tự động đổi hình nền"]);

                System.Threading.Tasks.Task.run(Bridge.fn.bind(this, function () {
                    var $step = 0,
                        $task1, 
                        $taskResult1, 
                        $jumpFromFinally, 
                        $tcs = new System.Threading.Tasks.TaskCompletionSource(), 
                        $returnValue, 
                        setting, 
                        clientSetting, 
                        $async_e, 
                        $asyncBody = Bridge.fn.bind(this, function () {
                            try {
                                for (;;) {
                                    $step = System.Array.min([0,1], $step);
                                    switch ($step) {
                                        case 0: {
                                            $task1 = ClientScript.Component.GET("Setting");
                                            $step = 1;
                                            $task1.continueWith($asyncBody);
                                            return;
                                        }
                                        case 1: {
                                            $taskResult1 = $task1.getAwaitedResult();
                                            setting = $taskResult1;
                                            ClientScript.App.Append(setting);

                                            clientSetting = new CDesktopWallper.ClientSetting();
                                            clientSetting.OnComplete = Bridge.fn.bind(this, function () {
                                                this.LoadSettings(clientSetting);
                                            });

                                            this.BtnActiveOnClick();
                                            $tcs.setResult(null);
                                            return;
                                        }
                                        default: {
                                            $tcs.setResult(null);
                                            return;
                                        }
                                    }
                                }
                            } catch($async_e1) {
                                $async_e = System.Exception.create($async_e1);
                                $tcs.setException($async_e);
                            }
                        }, arguments);

                    $asyncBody();
                    return $tcs.task;
                }));
            }
        },
        methods: {
            LoadSettings: function (clientSetting) {
                var $t, $t1;
                var settingItem = jQuery("input[id^='setting.']");
                $t = Bridge.getEnumerator(settingItem);
                try {
                    while ($t.moveNext()) {
                        var item = $t.Current;
                        var SetChecked = null;

                        var name = ($t1 = System.String.split(item.id, System.String.toCharArray(("."), 0, (".").length).map(function (i) {{ return String.fromCharCode(i); }})))[1];
                        var value = false;
                        switch (name) {
                            case "AutoWallper": 
                                value = ClientScript.Exensions.ObjectExt.GetField(System.Boolean, clientSetting.Data, name);
                                break;
                            case "InternetWallperSource": 
                                value = Bridge.referenceEquals(clientSetting.Data.WallerSource, "InternetWallperSource");
                                break;
                            case "LocalWallperSource": 
                                value = Bridge.referenceEquals(clientSetting.Data.WallerSource, "LocalWallperSource");
                                break;
                            default: 
                                break;
                        }
                        SetChecked = function (_name, _value) {
                            var id = System.String.format("setting.{0}", [_name]);
                            if (_value) {
                                document.getElementById(id).setAttribute("checked", "true");
                            } else {
                                document.getElementById(id).removeAttribute("checked");
                            }
                        };

                        SetChecked(name, value);

                    }
                } finally {
                    if (Bridge.is($t, System.IDisposable)) {
                        $t.System$IDisposable$Dispose();
                    }
                }
            },
            BtnActiveOnClick: function () {
                var btnActive = document.getElementById("btnActive");
                if (btnActive != null) {
                    btnActive.onclick = function (e) {
                        if (Bridge.referenceEquals(btnActive.innerText, "Kích hoạt")) {
                            ClientScript.SettingWebViewWSClient.Start();
                            btnActive.innerText = "Ngưng";
                        } else {
                            ClientScript.SettingWebViewWSClient.Stop();
                            btnActive.innerText = "Kích hoạt";
                        }
                    };
                }
            }
        }
    });

    Bridge.define("ClientScript.WallperPreviewCard", {
        fields: {
            Title: null,
            Status: null,
            Wallper: null,
            Thumb: null
        },
        methods: {
            toString: function () {
                var myvar = new System.Text.StringBuilder();
                if (System.String.isNullOrEmpty(this.Thumb)) {
                    this.Thumb = this.Wallper;
                }



                myvar.append("<div class=\"col-md-4\">").append("<div class=\"card\">").append("<div class=\"card-header\">").append(System.String.format("<strong class=\"card-title\">{0}<small><span class=\"badge badge-success float-right mt-1\">{1}</span></small></strong>", this.Title, this.Status)).append("</div>").append("<div class=\"card-body\">").append("<p>").append("<button type=\"button\" name='SetWallper' class=\"btn btn-outline-primary\" ><i class=\"fa fa-star\"></i>&nbsp; Chọn </button>").append("</p>").append(System.String.format("<img src=\"{0}\" data-src=\"{1}\" class=\"lazy img-thumbnail\" alt=\"{2}\">", this.Thumb, this.Wallper, this.Wallper)).append("</div>").append("</div>").append("</div>");
                return myvar.toString();
            }
        }
    });

    Bridge.define("Javascript");

    /**
     * Định nghĩa này để gọi 1 số hàm json sẵn có của browser
     *
     * @static
     * @abstract
     * @public
     * @class Json
     */
    Bridge.define("Json", {
        statics: {
            methods: {
                /**
                 * @static
                 * @public
                 * @this Json
                 * @memberof Json
                 * @param   {object}    data
                 * @return  {string}
                 */
                Stringify: function (data) {
                    return JSON.stringify(data);
                },
                Parse: function (json) {
                    return JSON.parse(json);
                }
            }
        }
    });

    /**
     * @memberof Retyped
     * @callback Retyped.jquery.JQuery.Ajax.ErrorCallback
     * @param   {Retyped..JQuery.jqXHR$1}    jqXHR          
     * @param   {System.String}              textStatus     
     * @param   {string}                     errorThrown
     * @return  {void}
     */

    /** @namespace Retyped */

    /**
     * @memberof Retyped
     * @callback Retyped.jquery.JQuery.Ajax.SuccessCallback
     * @param   {System.Object}              data          
     * @param   {System.String}              textStatus    
     * @param   {Retyped..JQuery.jqXHR$1}    jqXHR
     * @return  {void}
     */

    Bridge.define("Kernel.Ajax", {
        fields: {
            /**
             * Hàm sẽ gọi khi thực gọi ajax thành công
             *
             * @instance
             * @public
             * @memberof Kernel.Ajax
             * @function success
             * @type Retyped.jquery.JQuery.Ajax.SuccessCallback
             */
            success: null,
            request: null,
            /**
             * Hàm sẽ gọi khi thực gọi ajax thất bại
             *
             * @instance
             * @public
             * @memberof Kernel.Ajax
             * @function error
             * @type Retyped.jquery.JQuery.Ajax.ErrorCallback
             */
            error: null,
            /**
             * relative or absolute url
             *
             * @instance
             * @public
             * @memberof Kernel.Ajax
             * @function Url
             * @type string
             */
            Url: null,
            /**
             * ajax data
             *
             * @instance
             * @public
             * @memberof Kernel.Ajax
             * @function data
             * @type System.Object
             */
            data: null,
            /**
             * Asynchronous
             *
             * @instance
             * @public
             * @memberof Kernel.Ajax
             * @function Async
             * @type boolean
             */
            Async: false,
            /**
             * Http Method
             *
             * @instance
             * @public
             * @memberof Kernel.Ajax
             * @function Method
             * @type string
             */
            Method: null,
            /**
             * Nếu ValidDataType khác null thì
              : Kiểm tra kiểu dữ liệu trước khi gửi ajax.
             Nếu nó bằng null thì không kiểm tra.
             *
             * @instance
             * @private
             * @memberof Kernel.Ajax
             * @default true
             * @type boolean
             */
            _isValidRequest: false
        },
        ctors: {
            init: function () {
                this._isValidRequest = true;
            },
            ctor: function () {
                this.$initialize();
                this.SetDefaultParameters();
            }
        },
        methods: {
            /**
             * Thiết lập tham số mặc định
             *
             * @instance
             * @public
             * @this Kernel.Ajax
             * @memberof Kernel.Ajax
             * @return  {void}
             */
            SetDefaultParameters: function () {
                this.Async = true;
                this.Method = "GET";
            },
            /**
             * Gọi ajax
             *
             * @instance
             * @public
             * @this Kernel.Ajax
             * @memberof Kernel.Ajax
             * @return  {void}
             */
            Request: function () {
                this.ValidateRequest();
                this.PrepareAjaxOptions();
                if (this._isValidRequest) {
                    this.request = jQuery.ajax({ data: this.data, async: this.Async, method: this.Method, url: this.Url, success: this.success, error: this.error });
                }
            },
            ValidateRequest: function () {
                this._isValidRequest = !System.String.isNullOrWhiteSpace(this.Url);

                if (!this._isValidRequest) {
                    this.ShowMessageForNotValidRequest();
                }
            },
            ShowMessageForNotValidRequest: function () {
                alert("Request không hợp lệ");
                var ajaxRequestParams = { Url: this.Url, data: this.data, Method: this.Method, Async: this.Async };
                System.Console.WriteLine("Request không hợp lệ : ");
                System.Console.WriteLine(ajaxRequestParams);
            },
            ShowNotSupportMethod: function () {
                System.Console.WriteLine("Hiện tại thư viện chưa hỗ trợ phương thức này");
            },
            PrepareAjaxOptions: function () {
                var $t;
                if (this.data == null) {
                    this.data = { };
                }
                do {
                    ($t = Bridge.Reflection.getTypeName(Bridge.getType(this.data)));
                    if (Bridge.referenceEquals($t, "String")) {
                        this.Url = System.String.concat(this.Url, this.data);
                        this.data = { };
                        break;
                    }

                    if (Bridge.referenceEquals($t, "Object")) {
                        if (Bridge.referenceEquals(this.Method, "GET")) {
                            this.data = jQuery.param(this.data);
                            break;
                        }
                    }

                    if (Bridge.referenceEquals($t, "Object")) {
                        if (Bridge.referenceEquals(this.Method, "POST")) {
                            break;
                        }
                    }

                    {
                        this.data = jQuery.param(this.data.toJSON());
                        break;
                    }
                } while (false);
            }
        }
    });

    Bridge.define("Kernel.Attributes.EventHandlerAttribute", {
        inherits: [System.Attribute],
        ctors: {
            ctor: function (msg) {
                if (msg === void 0) { msg = ""; }

                this.$initialize();
                System.Attribute.ctor.call(this);
                if (!System.String.isNullOrWhiteSpace(msg)) {
                    System.Console.WriteLine(msg);
                }
            }
        }
    });

    Bridge.define("Kernel.Attributes.TestedAttribute", {
        inherits: [System.Attribute],
        ctors: {
            ctor: function (msg) {
                if (msg === void 0) { msg = ""; }

                this.$initialize();
                System.Attribute.ctor.call(this);
                if (!System.String.isNullOrWhiteSpace(msg)) {
                    System.Console.WriteLine(msg);
                }
            }
        }
    });

    Bridge.define("Kernel.Class");

    /** @namespace Kernel.Data */

    /**
     * Thông số của popup hiện lên
     *
     * @public
     * @class Kernel.Data.popupNotificationConst
     */
    Bridge.define("Kernel.Data.popupNotificationConst", {
        statics: {
            fields: {
                Sucess: null,
                Error: null
            },
            ctors: {
                init: function () {
                    this.Sucess = "success";
                    this.Error = "error";
                }
            }
        }
    });

    Bridge.define("Kernel.KendoDatePicker", {
        fields: {
            /**
             * kendo namespace
             *
             * @instance
             * @public
             * @memberof Kernel.KendoDatePicker
             * @type object
             */
            kendo: null,
            /**
             * Jquery prefix
             *
             * @instance
             * @public
             * @memberof Kernel.KendoDatePicker
             * @type object
             */
            jquery: null,
            _kendoDatePickerId: null,
            datePicker: null
        },
        props: {
            /**
             * Truy cập @this khi đang trong hàm xử lý event
             *
             * @instance
             * @public
             * @readonly
             * @memberof Kernel.KendoDatePicker
             * @function this
             * @type Kernel.KendoDatePicker
             */
            this: {
                get: function () {
                    return new Kernel.KendoDatePicker(this._kendoDatePickerId);
                }
            },
            object: {
                get: function () {
                    return document.getElementById(Kernel.SelectorExtensions.Id(this._kendoDatePickerId));
                }
            }
        },
        ctors: {
            init: function () {
                this.kendo = kendo;
                this.jquery = jQuery;
            },
            ctor: function (Id) {
                this.$initialize();
                this._kendoDatePickerId = Id;
                this.datePicker = this.jquery(Kernel.SelectorExtensions.Id(this._kendoDatePickerId)).data("kendoDatePicker");
                this.jquery(Kernel.SelectorExtensions.Id(this._kendoDatePickerId)).kendoDatePicker();

            }
        },
        methods: {
            GetDateTime: function () {
                return this.datePicker.value();
            },
            SetDateTime: function (dateTime) {
                try {
                    var kendoTime = this.kendo.toString(this.kendo.parseDate(dateTime), "MM/dd/yyyy");
                    this.datePicker.value(kendoTime);

                } catch (err) {
                    err = System.Exception.create(err);
                    System.Console.WriteLine(System.String.format("Error :{0}", [err.Message]));
                }

            },
            /**
             * Lấy ngày hiện tại và chọn ngày này
             *
             * @instance
             * @public
             * @this Kernel.KendoDatePicker
             * @memberof Kernel.KendoDatePicker
             * @return  {void}
             */
            SetToday: function () {
                var datePicker = new Kernel.KendoDatePicker(this._kendoDatePickerId);
                datePicker.SetDateTime(System.DateTime.getNow());
            },
            /**
             * Làm cho datepicker trở thành width 100%
             *
             * @instance
             * @public
             * @this Kernel.KendoDatePicker
             * @memberof Kernel.KendoDatePicker
             * @return  {void}
             */
            getFullWidth: function () {
                this["this"];
                this.this.object;
            },
            /**
             * Làm cho datepicker chỉ đọc , không ghi được
             *
             * @instance
             * @public
             * @this Kernel.KendoDatePicker
             * @memberof Kernel.KendoDatePicker
             * @return  {void}
             */
            ReadOnly: function () {
                this.jquery(Kernel.SelectorExtensions.Id(this._kendoDatePickerId)).attr("readonly", true);
            }
        }
    });

    Bridge.define("Kernel.Others.IVoid", {
        $kind: "interface"
    });

    Bridge.define("Kernel.Http.HttpMethod");

    Bridge.define("Kernel.Others.IFunction", {
        $kind: "interface"
    });

    Bridge.define("Kernel.SelectorExtensions", {
        statics: {
            methods: {
                Id: function (name) {
                    return "#" + (name || "");
                },
                Class: function (name) {
                    return "#" + (name || "");
                },
                Tag: function (name) {
                    return name;
                }
            }
        }
    });

    Bridge.define("Shared.WsCommand", {
        fields: {
            Command: null,
            JsonData: null
        }
    });

    Bridge.define("support", {
        statics: {
            methods: {
                clearInnerHtml: function (element) {

                    element.innerHTML = "";
                },
                plusText: function (element, text) {
                    var $t;
                    if (!element.isConnected) {
                        alert("Không thể thực hiện hành động này");
                    }

                    var textSpan = ($t = document.createElement("span"), $t.innerText = text, $t);

                    element.insertAdjacentElement("afterend", textSpan);
                }
            }
        }
    });

    Bridge.define("CDesktopWallper.ClientSetting", {
        inherits: [CDesktopWallper.IClientSetting],
        statics: {
            fields: {
                Socket: null
            },
            ctors: {
                init: function () {
                    this.Socket = new WebSocket(ClientScript.Resource.Instance.SettingWebViewWS);
                }
            },
            methods: {
                Set: function (name, value) {
                    var $t, $t1;
                    var wsSetCommand = ($t = new Shared.WsCommand(), $t.Command = "SET", $t.JsonData = Json.Stringify(($t1 = new CDesktopWallper.SettingCommand(), $t1.Name = name, $t1.Value = value, $t1)), $t);
                    CDesktopWallper.ClientSetting.Socket.send(Json.Stringify(wsSetCommand));
                }
            }
        },
        fields: {
            Data: null,
            OnComplete: null
        },
        alias: [
            "Data", "CDesktopWallper$IClientSetting$Data",
            "Load", "CDesktopWallper$IClientSetting$Load",
            "Save", "CDesktopWallper$IClientSetting$Save"
        ],
        ctors: {
            ctor: function () {
                this.$initialize();
                CDesktopWallper.ClientSetting.Socket.onmessage = Bridge.fn.bind(this, function (message) {
                    try {
                        var ws = Newtonsoft.Json.JsonConvert.DeserializeObject(message.data, Shared.WsCommand);
                        switch (ws.Command) {
                            case "READ": 
                                debugger;
                                this.Data = Json.Parse(ws.JsonData);
                                !Bridge.staticEquals(this.OnComplete, null) ? this.OnComplete() : null;
                                break;
                            default: 
                                break;
                        }
                    } catch ($e1) {
                        $e1 = System.Exception.create($e1);
                        console.log(message.data);
                    }

                });
                CDesktopWallper.ClientSetting.Socket.onopen = Bridge.fn.bind(this, function (open) {
                    this.Load();
                });
            }
        },
        methods: {
            Load: function () {
                var $t;
                var READ = ($t = new Shared.WsCommand(), $t.Command = "READ", $t);
                CDesktopWallper.ClientSetting.Socket.send(Json.Stringify(READ));
            },
            Save: function () {

            }
        }
    });

    Bridge.define("CDesktopWallper.ClientSettingData", {
        inherits: [CDesktopWallper.IClientSettingData],
        fields: {
            _AutoWallper: false,
            WallerSource: null,
            Wallpers: null,
            UrlSubscriptions: null,
            Keywords: null,
            Locale: null
        },
        props: {
            AutoWallper: {
                get: function () {
                    return this._AutoWallper;
                },
                set: function (value) {
                    CDesktopWallper.ClientSetting.Set("AutoWallper", value);
                    this._AutoWallper = value;
                }
            }
        },
        alias: [
            "AutoWallper", "CDesktopWallper$IClientSettingData$AutoWallper",
            "WallerSource", "CDesktopWallper$IClientSettingData$WallerSource",
            "Wallpers", "CDesktopWallper$IClientSettingData$Wallpers",
            "UrlSubscriptions", "CDesktopWallper$IClientSettingData$UrlSubscriptions",
            "Keywords", "CDesktopWallper$IClientSettingData$Keywords",
            "Locale", "CDesktopWallper$IClientSettingData$Locale"
        ]
    });

    Bridge.define("ClientScript.WallperPage", {
        inherits: [System.Collections.Generic.List$1(ClientScript.WallperPreviewCard)],
        methods: {
            toString: function () {
                var $t;
                var s = new System.Text.StringBuilder();
                $t = Bridge.getEnumerator(this);
                try {
                    while ($t.moveNext()) {
                        var item = $t.Current;
                        s.append(item.toString());
                    }
                } finally {
                    if (Bridge.is($t, System.IDisposable)) {
                        $t.System$IDisposable$Dispose();
                    }
                }
                return s.toString();
            }
        }
    });

    Bridge.define("Kernel.AjaxTask", {
        inherits: [Kernel.Ajax],
        fields: {
            requestError: false,
            /**
             * Thời gian chờ dữ liệu tối đa, tính bằng mili giây
             *
             * @instance
             * @public
             * @memberof Kernel.AjaxTask
             * @function TimeCanWait
             * @type number
             */
            TimeCanWait: 0,
            AjaxResult: null
        },
        ctors: {
            ctor: function () {
                this.$initialize();
                Kernel.Ajax.ctor.call(this);
                this.Async = true;
                this.success = Bridge.fn.cacheBind(this, this._sucessTask);
                this.error = Bridge.fn.cacheBind(this, this._errorTask);
            }
        },
        methods: {
            Execute: function () {
                var $step = 0,
                    $task1, 
                    $taskResult1, 
                    $jumpFromFinally, 
                    $tcs = new System.Threading.Tasks.TaskCompletionSource(), 
                    $returnValue, 
                    Ajax, 
                    $async_e, 
                    $asyncBody = Bridge.fn.bind(this, function () {
                        try {
                            for (;;) {
                                $step = System.Array.min([0,1], $step);
                                switch ($step) {
                                    case 0: {
                                        this.PrepareAjaxOptions();
                                        Ajax = System.Threading.Tasks.Task.fromPromise(jQuery.ajax({ data: this.data, async: this.Async, method: this.Method, url: this.Url, success: Bridge.fn.cacheBind(this, this._sucessTask), error: Bridge.fn.cacheBind(this, this._errorTask) }));

                                        $task1 = System.Threading.Tasks.Task.whenAll(Ajax);
                                        $step = 1;
                                        $task1.continueWith($asyncBody);
                                        return;
                                    }
                                    case 1: {
                                        $taskResult1 = $task1.getAwaitedResult();
                                        $tcs.setResult(this.AjaxResult);
                                        return;
                                    }
                                    default: {
                                        $tcs.setResult(null);
                                        return;
                                    }
                                }
                            }
                        } catch($async_e1) {
                            $async_e = System.Exception.create($async_e1);
                            $tcs.setException($async_e);
                        }
                    }, arguments);

                $asyncBody();
                return $tcs.task;
            },
            _errorTask: function (jqXHR, textStatus, errorThrown) {
                this.requestError = true;
            },
            _sucessTask: function (data, textStatus, jqXHR) {
                this.requestError = false;
                this.AjaxResult = data;
            }
        }
    });

    Bridge.define("Kernel.KendoDatePickerEventHandler", {
        inherits: [Kernel.KendoDatePicker],
        ctors: {
            ctor: function (Id) {
                this.$initialize();
                Kernel.KendoDatePicker.ctor.call(this, Id);
                var object = document.getElementById(this._kendoDatePickerId);
                object.onchange = Bridge.fn.combine(object.onchange, Bridge.fn.cacheBind(this, this.onChange));
                object.onclick = Bridge.fn.combine(object.onclick, Bridge.fn.cacheBind(this, this.onClick));
                object.onmouseenter = Bridge.fn.combine(object.onmouseenter, Bridge.fn.cacheBind(this, this.onHover));
            }
        },
        methods: {
            onChange: function (obj) {

            },
            onClick: function (obj) {


            },
            onHover: function (obj) {


            }
        }
    });

    Bridge.define("Kernel.Function", {
        inherits: [Kernel.Others.IVoid],
        alias: ["Execute", "Kernel$Others$IVoid$Execute"],
        ctors: {
            ctor: function () {
                this.$initialize();

            }
        },
        methods: {
            /**
             * Gọi hàm này để thực thi một function class
             *
             * @instance
             * @public
             * @this Kernel.Function
             * @memberof Kernel.Function
             * @return  {void}
             */
            Execute: function () { },
            /**
             * Khởi tạo các biến
             *
             * @instance
             * @public
             * @this Kernel.Function
             * @memberof Kernel.Function
             * @return  {void}
             */
            VariablesInit: function () { }
        }
    });

    Bridge.define("Kernel.DatePicker", {
        inherits: [Kernel.KendoDatePickerEventHandler],
        ctors: {
            ctor: function () {
                this.$initialize();
                Kernel.KendoDatePickerEventHandler.ctor.call(this, "datepicker");

            }
        },
        methods: {
            onChange: function (obj) {
                this.this.SetToday();

            },
            onClick: function (obj) {

            },
            onHover: function (obj) {

            }
        }
    });

    Bridge.define("Kernel.Dependecies.EnsureLibrariesInstalledCorrectly_func", {
        inherits: [Kernel.Function],
        fields: {
            dependencies: null
        },
        alias: ["Execute", "Kernel$Others$IVoid$Execute"],
        ctors: {
            ctor: function () {
                this.$initialize();
                Kernel.Function.ctor.call(this);
                this.PrepareDependenciesList();
            }
        },
        methods: {
            PrepareDependenciesList: function () {
                this.dependencies = function (_o1) {
                        _o1.add("jquery.jQuery");
                        return _o1;
                    }(new (System.Collections.Generic.List$1(System.String)).ctor());
            },
            Success: function (lib) {
                System.Console.WriteLine(System.String.format("- <p style='color:green;'> {0} đã ok </p>", [lib]));
            },
            Error: function (lib) {
                System.Console.WriteLine(System.String.format(" <p style='color:red;'>Chưa thêm thư viện {0} vào dự án</p>", [lib]));
            },
            CheckifLibraryInstalled: function (lib) {
                try {
                    var x = lib;
                    var k = x.isPrototypeOf(undefined);
                    return Bridge.fn.cacheBind(this, this.Success);
                } catch ($e1) {
                    $e1 = System.Exception.create($e1);
                    return Bridge.fn.cacheBind(this, this.Error);
                }
            },
            Execute: function () {
                var $t;
                $t = Bridge.getEnumerator(this.dependencies);
                try {
                    while ($t.moveNext()) {
                        var lib = $t.Current;
                        System.Console.Write(System.String.format("Kiểm tra thư viện {0} tồn tại?", [lib]));
                        this.CheckifLibraryInstalled(lib)(lib);
                    }
                } finally {
                    if (Bridge.is($t, System.IDisposable)) {
                        $t.System$IDisposable$Dispose();
                    }
                }
            }
        }
    });

    Bridge.define("Kernel.Dependecies.DI", {
        inherits: [Kernel.Dependecies.EnsureLibrariesInstalledCorrectly_func],
        methods: {
            PrepareDependenciesList: function () {
                Kernel.Dependecies.EnsureLibrariesInstalledCorrectly_func.prototype.PrepareDependenciesList.call(this);
                this.dependencies.add("TestLib2");
            },
            Error: function (lib) {
                System.Console.WriteLine((System.String.format("Kiểu thông báo lỗi thứ 2 : Lỗi ", null) || "") + (lib || ""));
            },
            Success: function (lib) {
                System.Console.WriteLine(System.String.format("Ờ chạy được rồi nhé : {0}", [lib]));
            }
        }
    });
});
