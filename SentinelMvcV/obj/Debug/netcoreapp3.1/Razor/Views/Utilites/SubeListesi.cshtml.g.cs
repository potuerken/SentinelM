#pragma checksum "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60a3d46ced4522671cc2ca4b4e926fa9a126160f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Utilites_SubeListesi), @"mvc.1.0.view", @"/Views/Utilites/SubeListesi.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\_ViewImports.cshtml"
using SentinelMvcV;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\_ViewImports.cshtml"
using SentinelMvcV.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
using Check.DTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
using SentinelMvcV.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"60a3d46ced4522671cc2ca4b4e926fa9a126160f", @"/Views/Utilites/SubeListesi.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4df7d4521399d423befa10328f6114cd65304117", @"/Views/_ViewImports.cshtml")]
    public class Views_Utilites_SubeListesi : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KodSubeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
  
    ViewData["Title"] = "Şube Listesi";
    Layout = "~/Views/Shared/_Layout.cshtml";


    List<KodDTO> subeList = (List<KodDTO>)TempData["SubeDD"];

    var SuccessMessage = (string)TempData["SuccessMessage"];
    var FailedMessage = (string)TempData["FailedMessage"];

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""form-group"">
        <div class=""row"">
            <div class=""col-md-2"">
                <button style=""margin-top:10px;"" type=""button"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#AddedSubeModal"" onClick=""AddedMessage()"">
                    Yeni Şube Ekle
                </button>
            </div>
        </div>
");
#nullable restore
#line 24 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
         if (SuccessMessage != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div style=\"margin-top:10px;\" class=\"alert alert-success\" role=\"alert\">\r\n                <span>");
#nullable restore
#line 27 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
                 Write(SuccessMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n");
#nullable restore
#line 29 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
         if (FailedMessage != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div style=\"margin-top:10px;\" class=\"alert alert-danger\" role=\"alert\">\r\n                <span>");
#nullable restore
#line 33 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
                 Write(FailedMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n");
#nullable restore
#line 35 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""mb-2""></div>

        <table id=""SubeListDT"" class=""table table-striped table-bordered"" style=""width:100%"">
            <thead>
                <tr>
                    <th>SN</th>
                    <th style=""text-align:center"">Şube Adı</th>
                    <th style=""text-align:center"">Detay</th>
                    <th style=""text-align:center"">Düzenle</th>
                    <th style=""text-align:center"">Sil</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 49 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
                 foreach (KodDTO item in subeList)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td></td>\r\n                        <td>");
#nullable restore
#line 53 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
                       Write(item.Ad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"text-align:center\">");
#nullable restore
#line 54 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
                                                 Write(Html.ActionLink("Detay", "YakitListesi", "VAKA", new { id = @item.Id }, new { @class = "btn btn-success btn-block" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"text-align:center\"><button type=\"button\" class=\"btn btn-secondary btn-block\" data-toggle=\"modal\" data-target=\"#UpdateSubeModal\"");
            BeginWriteAttribute("onClick", " onClick=\"", 2210, "\"", 2257, 5);
            WriteAttributeValue("", 2220, "UpdatedMessage(\'", 2220, 16, true);
#nullable restore
#line 55 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
WriteAttributeValue("", 2236, item.Id, 2236, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2244, "\',\'", 2244, 3, true);
#nullable restore
#line 55 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
WriteAttributeValue("", 2247, item.Ad, 2247, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2255, "\')", 2255, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Düzenle</button></td>\r\n                        <td style=\"text-align:center\"><button type=\"button\" class=\"btn btn-danger btn-block\" data-toggle=\"modal\" data-target=\"#DeletedSubeModal\"");
            BeginWriteAttribute("onClick", " onClick=\"", 2442, "\"", 2506, 7);
            WriteAttributeValue("", 2452, "DeletedMessage(\'", 2452, 16, true);
#nullable restore
#line 56 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
WriteAttributeValue("", 2468, item.Id, 2468, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2476, "\',\'", 2476, 3, true);
#nullable restore
#line 56 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
WriteAttributeValue("", 2479, item.Ad, 2479, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2487, "\',\'", 2487, 3, true);
#nullable restore
#line 56 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
WriteAttributeValue("", 2490, item.UstKodId, 2490, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2504, "\')", 2504, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Sil</button></td>\r\n                    </tr>\r\n");
#nullable restore
#line 58 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</div>\r\n\r\n");
#nullable restore
#line 66 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
 using (Html.BeginForm("SubeCrud", "Utilites", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
Write(Html.HiddenFor(model => model.CrudSubeKodDTO.Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
                                                     ;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal fade"" id=""AddedSubeModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""AddedSubeModalLabel"" aria-hidden=""true"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""AddedSubeModalLabel"">Şube Müdürlüğü Ekleme İşlemleri</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"" onclick=""AddedReflesh()"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    ");
#nullable restore
#line 80 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
               Write(Html.TextBoxFor(a => a.CrudSubeKodDTO.Ad, new { @class = "form-control", @id = "txtSubeAdAdded", @placeholder = "eklenecek şube adı", @autocomplete = "off", @autofocus = "autofocus" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"" onclick=""AddedReflesh()"">Kapat</button>
                    <button id=""btnSubeAdded"" type=""submit"" class=""btn btn-success"">Şube Ekle</button>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 89 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 91 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
 using (Html.BeginForm("SubeCrud", "Utilites", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 93 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 94 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
Write(Html.HiddenFor(model => model.CrudSubeKodDTO.Id, new { id = "hdnUpdatedSubeId" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 94 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
                                                                                      ;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal fade"" id=""UpdateSubeModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""UpdateSubeModalLabel"" aria-hidden=""true"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""UpdateSubeModalLabel"">Şube Müdürlüğü Düzenleme İşlemleri</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"" onclick=""UpdatedReflesh()"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    ");
#nullable restore
#line 105 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
               Write(Html.TextBoxFor(a => a.CrudSubeKodDTO.Ad, new { @class = "form-control", @id = "txtSubeAdUpdated", @placeholder = "şubenin yeni adı", @autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"" onclick=""UpdatedReflesh()"">Kapat</button>
                    <button id=""btnSubeUpdated"" type=""submit"" class=""btn btn-success"">Değiştir</button>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 114 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 117 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
 using (Html.BeginForm("SubeCrud", "Utilites", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 119 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
Write(Html.HiddenFor(model => model.CrudSubeKodDTO.Id, new { id = "hdnDeletedSubeId" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 119 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
                                                                                      ;
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 120 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
Write(Html.HiddenFor(model => model.CrudSubeKodDTO.UstKodId, new { id = "hdnDeletedSubeUstKodId"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal fade"" id=""DeletedSubeModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""DeletedSubeModalLabel"" aria-hidden=""true"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""DeletedSubeModalLabel"">Şube Kapatma İşlemi</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"" onclick=""DeletedReflesh()"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <div class=""col-md-12"">");
#nullable restore
#line 131 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
                                      Write(Html.TextBoxFor(a => a.CrudSubeKodDTO.Ad, new { @class = "form-control", @id = "txtSubeAdiDeleted", @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                    <div class=""mb-3""></div>
                    <div class=""col-md-12""><span>Silmek istediğine emin misin ?</span></div>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"" onclick=""DeletedReflesh()"">Vazgeçtim...</button>
                    <button type=""submit"" class=""btn btn-danger"">Sil Sil Sil!</button>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 142 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Utilites\SubeListesi.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<script>
    var tarih = new Date();
    var yil = tarih.getFullYear();
    var ay = tarih.getMonth();
    var gun = tarih.getDate();
    var saat = tarih.getHours();
    var dakika = tarih.getMinutes();
    var saniye = tarih.getSeconds();

    $(document).ready(function () {
        $('#AddedSubeModal').on('shown.bs.modal', function () {
            $('#txtSubeAdAdded').trigger('focus');
        });

        var table = $('#SubeListDT').DataTable({
            dom: 'Bfrtip',
            // Page kaçlı listeler halinde gelmesi için
            lengthChange: false,
            // Page li kısmın buton şeklinde görünmesi için
            lengthMenu: [
                [10, 25, 50, -1],
                ['10 Kayıt', '25 Kayıt', '50 Kayıt', 'Tümü']
            ],
            // Çıktı Butonları
            buttons: [
                { extend: 'copy', text: 'Kopyala' },
                {
                    // Çıktının tipi
                    extend: 'excel',
                    // Çı");
            WriteLiteral(@"ktının hangi kolonlarının görünür olması için
                    exportOptions: {
                        columns: [0, 1]
                    },
                    // Çıktının dosya ismi
                    title: 'Şube Müdürlükleri Listesi ' + gun + '-' + (ay + 1) + '-' + yil + '__' + saat + ':' + dakika + ':' + saniye,
                    text: 'Excel'
                },
                // Kaçlı listeler halinde görünsün
                { extend: 'pageLength', text: 'Görüntülenme' },
                // PDF olarak çıktı al
                {
                    // Çıktının tipi
                    extend: 'pdf',
                    // Çıktının hangi kolonlarının görünür olması için
                    exportOptions: {
                        columns: [0, 1]
                    },
                    // Çıktının dosya ismi
                    title: 'Şube Müdürlükleri Listesi ' + gun + '-' + (ay + 1) + '-' + yil + '__' + saat + ':' + dakika + ':' + saniye
                },
             ");
            WriteLiteral(@"   // Sütunlardan hangisi görünsün
                { extend: 'colvis', text: 'Sütun Gizle/Göster' }],
            language: {

                ""emptyTable"": ""Mevcut veri yok."",
                ""info"": ""Toplam _TOTAL_ kayıttan _START_ ile _END_ arasındaki kayıtlar."",
                ""infoEmpty"": ""Arama sonucu veri bulunamadı."",
                ""infoFiltered"": ""(toplam _MAX_ kayıt içinde arandı.)"",
                ""loadingRecords"": ""Yükleniyor..."",
                ""search"": ""Ara:"",
                ""zeroRecords"": ""Hiçbir eşleşen kayıt bulunamadı"",
                ""paginate"": {
                    ""first"": ""İlk"",
                    ""last"": ""Son"",
                    ""next"": ""Sonraki"",
                    ""previous"": ""Önceki""
                }
            },
            // Alttaki sayfa numaralarının hepsi görünsün
            ""pagingType"": ""full_numbers"",
            // Sütunların sıralamasını kullanıcının değiştirilebilir olması yapar.
            colReorder: true,
            // columnDef");
            WriteLiteral(@" özelliğini açar olarak anladım.
            rowReorder: true,
            // Targets olarak seçtiğin indeks sıralamasına göre sütunların order özelliği açılır kapanır.
            columnDefs: [
                { width: '4%', targets: 0 },
                { searchable: true, orderable: true, className: 'reorder', targets: 1 },
                { searchable: false, orderable: false, targets: '_all' }
            ],
            order: [[1, ""asc""]],
            stateSave: true
        });

        table.on('order.dt search.dt', function () {
            table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
                cell.innerHTML = i + 1;
                table.cell(cell).invalidate('dom');
            });
        }).draw();

        // Butonların bootstrap tipi görünürlüğü sağlar
        table.buttons().container()
            .appendTo('#example_wrapper .col-md-6:eq(0)');


        // Menüdeki üst başlığın kalın olması için
        $(""#listUtil");
            WriteLiteral(@"itesAnaBaslik"").attr('class', 'nav-item active');
        // Menünün tüm alt başlıklarını açık tutmak için
        $(""#utilitesMenusu"").attr('class', 'collapse show');
        // Seçilen alt başlığın baskın olması için
        $(""#subeButonu"").attr('class', 'collapse-item active');
        // Seçildiğinde okun aşağı doğru bakması için
        $(""#utilitesOkYonu"").toggleClass('collapsed');



        $(""#btnSubeUpdated"").prop(""disabled"", true);
        $(""#btnSubeAdded"").prop(""disabled"", true);
    });



    function AddedMessage() {
        $(""#txtSubeAdAdded"").val(null);
        $(""#btnSubeAdded"").prop(""disabled"", true);
        $(function () {
            $('#txtSubeAdAdded').on('keyup change', function () {
                if (this.value.length > 0) {
                    $(""#btnSubeAdded"").prop(""disabled"", false);
                } else {
                    $(""#btnSubeAdded"").prop(""disabled"", true);
                }
            });
        });
    }

    function AddedRefle");
            WriteLiteral(@"sh() {
        $(""#txtSubeAdAdded"").val(null);
    }

    function UpdatedReflesh() {
        $(""#hdnUpdatedSubeId"").val(0);
        $(""#txtSubeAdUpdated"").val(null);
    }

    function DeletedReflesh() {
        $(""#hdnDeletedSubeId"").val(0);
        $(""#txtSubeAdiDeleted"").val(null);
    }

    function UpdatedMessage(id, name) {
        $(""#hdnUpdatedSubeId"").val(id);
        $(""#txtSubeAdUpdated"").val(name);
        $(""#btnSubeUpdated"").prop(""disabled"", true);
        $(function () {
            $('#txtSubeAdUpdated').on('keyup change', function () {
                if (this.value.length > 0) {
                    $(""#btnSubeUpdated"").prop(""disabled"", false);
                } else {
                    $(""#btnSubeUpdated"").prop(""disabled"", true);
                }
            });
        });
    }

    function DeletedMessage(id, name, ustkod) {
        $(""#hdnDeletedSubeId"").val(id);
        $(""#txtSubeAdiDeleted"").val(name);
        $(""#hdnDeletedSubeUstKodId"").val(ustk");
            WriteLiteral("od);\r\n    }\r\n</script>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KodSubeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
