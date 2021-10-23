#pragma checksum "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f990dd35413ba3181f9088259378e1f125eb4bed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Personel_IzinMazeretListesi), @"mvc.1.0.view", @"/Views/Personel/IzinMazeretListesi.cshtml")]
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
#line 1 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
using Check.DTO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
using SentinelMvcV.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f990dd35413ba3181f9088259378e1f125eb4bed", @"/Views/Personel/IzinMazeretListesi.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4df7d4521399d423befa10328f6114cd65304117", @"/Views/_ViewImports.cshtml")]
    public class Views_Personel_IzinMazeretListesi : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IzinMazeretViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
  
    ViewData["Title"] = "İzin Mazeret Listesi";
    Layout = "~/Views/Shared/_Layout.cshtml";

    List<KodDTO> izinDD = (List<KodDTO>)TempData["IzinDD"];
    List<PersonelDTO> personelDD = (List<PersonelDTO>)TempData["PersonelListesi"];
    List<IzinMazeretDTO> izinMazeretListesi = (List<IzinMazeretDTO>)TempData["IzinListesi"];

    var SuccessMessage = (string)TempData["SuccessMessage"];
    var FailedMessage = (string)TempData["FailedMessage"];

    List<SelectListItem> izinList = new List<SelectListItem>();
    foreach (var item in izinDD)
    {
        izinList.Add(new SelectListItem()
        {
            Text = item.Ad,
            Value = item.Id.ToString()
        });
    }

    List<SelectListItem> personelList = new List<SelectListItem>();
    foreach (var item in personelDD)
    {
        personelList.Add(new SelectListItem()
        {
            Text = item.Ad + " " + item.Soyad + " (" + item.Sicil + ")",
            Value = item.Id.ToString()
        });
    }



#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- #region HTML -->

<div class=""container-fluid"">
    <div class=""form-group"">
        <div class=""row"">
            <div class=""col-md-2"">
                <button style=""margin-top:10px;"" type=""button"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#AddedIzinModal"" onclick=""AddedIzinModalReflesh()"">
                    yeni izin mazeret ekle
                </button>
            </div>
        </div>
");
#nullable restore
#line 49 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
         if (SuccessMessage != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div style=\"margin-top:10px;\" class=\"alert alert-success\" role=\"alert\">\r\n                <span>");
#nullable restore
#line 52 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
                 Write(SuccessMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n");
#nullable restore
#line 54 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
         if (FailedMessage != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div style=\"margin-top:10px;\" class=\"alert alert-danger\" role=\"alert\">\r\n                <span>");
#nullable restore
#line 58 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
                 Write(FailedMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n");
#nullable restore
#line 60 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""mb-2""></div>

        <table id=""DTIzinListesi"" class=""table table-striped table-bordered"" style=""width:100%"">
            <thead>
                <tr>
                    <th>SN</th>
                    <th style=""text-align:center"">Sicil</th>
                    <th style=""text-align:center"">Ad</th>
                    <th style=""text-align:center"">Soyad</th>
                    <th style=""text-align:center"">İzin Başlangıç</th>
                    <th style=""text-align:center"">İzin Bitiş</th>
                    <th style=""text-align:center"">İzin Sebep</th>
                    <th style=""text-align:center"">İzin Durumu</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 77 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
                 foreach (IzinMazeretDTO item in izinMazeretListesi)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td></td>\r\n                        <td>");
#nullable restore
#line 81 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
                       Write(item.Personel.Sicil);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 82 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
                       Write(item.Personel.Ad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 83 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
                       Write(item.Personel.Soyad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 84 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
                       Write(item.BaslangicTarihi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 85 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
                       Write(item.BitisTarihi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 86 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
                       Write(item.IzinMazeretKod.Ad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 87 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
                       Write(item.Durumu);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 89 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</div>\r\n\r\n<!-- #endregion -->\r\n<!-- #region Added Modal -->\r\n\r\n");
#nullable restore
#line 99 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
 using (Html.BeginForm("IzinCrud", "Personel", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 101 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal fade bd-example-modal-lg"" id=""AddedIzinModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""AddedIzinModalLabel"" aria-hidden=""true"">
        <div class=""modal-dialog modal-lg"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"" id=""AddedIzinModalLabel"">personei izne/mazerete çıkarma işlemi</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"" onclick=""AddedIzinModalReflesh()"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <div class=""row"">
                        <div class=""col-md-6"">
                            <div class=""col-md-12 font-weight-bold"">izin/mazerete çıkacak personeli seçin</div>
                            <div class=""mb-1""></div>
                            <div class=""col-md-12"">
         ");
            WriteLiteral("                       ");
#nullable restore
#line 117 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
                           Write(Html.DropDownListFor(a => a.CrudIzin.Personel.Id, personelList, new { @class = "form-control", @id = "txtIzinPersonelAdded", @placeholder = "izne çıkacak personel", @required = "required", data_live_search = "true", title = "personeli seçin" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                            <div class=""mb-3""></div>

                            <div class=""col-md-12 font-weight-bold"">izin/mazeret başlangıç tarihi</div>
                            <div class=""mb-1""></div>
                            <div class=""col-md-12"">
                                ");
#nullable restore
#line 124 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
                           Write(Html.TextBoxFor(a => a.CrudIzin.BaslangicTarihi, new { @class = "form-control", @id = "txtIzinBaslangicTarihi", @placeholder = "başlangıç tarihi", @required = "required", @autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                            <div class=""mb-3""></div>
                        </div>

                        <div class=""col-md-6"">
                            <div class=""col-md-12 font-weight-bold"">izin/mazeret sebebi</div>
                            <div class=""mb-1""></div>
                            <div class=""col-md-12"">
                                ");
#nullable restore
#line 133 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
                           Write(Html.DropDownListFor(a => a.CrudIzin.IzinMazeretKod.Id, izinList, new { @class = "form-control", @id = "txtIzinSebepAdded", @placeholder = "sebebi seçin", @required = "required", data_live_search = "true", title = "sebebi seçin" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                            <div class=""mb-3""></div>

                            <div class=""col-md-12 font-weight-bold"">izin/mazeret başlangıç tarihi</div>
                            <div class=""mb-1""></div>
                            <div class=""col-md-12"">
                                ");
#nullable restore
#line 140 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
                           Write(Html.TextBoxFor(a => a.CrudIzin.BitisTarihi, new { @class = "form-control", @id = "txtIzinBitisTarihi", @placeholder = "bitiş tarihi", @required = "required", @autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </div>
                            <div class=""mb-3""></div>
                        </div>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"" onclick=""AddedIzinModalReflesh()"">Kapat</button>
                    <button id=""AddedIzinModalButton"" type=""submit"" class=""btn btn-success"">Kaydet</button>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 153 "C:\Users\tuna4lua\source\repos\SentinelM\SentinelMvcV\Views\Personel\IzinMazeretListesi.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- #endregion -->
<!-- #region Script -->

<script>

    var tarih = new Date();
    var yil = tarih.getFullYear();
    var ay = tarih.getMonth();
    var gun = tarih.getDate();
    var saat = tarih.getHours();
    var dakika = tarih.getMinutes();
    var saniye = tarih.getSeconds();


    $(document).ready(function () {
        $('#txtIzinBaslangicTarihi').datepicker({
            format: ""dd/mm/yyyy"",
            weekstart: 1,
            todaybtn: true,
            clearbtn: true,
            language: ""tr"",
            daysofweekhighlighted: ""0,6"",
            autoclose: true,
            todayhighlight: true
        });

        $('#txtIzinBitisTarihi').datepicker({
            format: ""dd/mm/yyyy"",
            weekstart: 1,
            todaybtn: true,
            clearbtn: true,
            language: ""tr"",
            daysofweekhighlighted: ""0,6"",
            autoclose: true,
            todayhighlight: true
        });
        $.fn.selectpicker.Constructor.Bootst");
            WriteLiteral(@"rapVersion = '4';

        $(function () {
            $('#txtIzinPersonelAdded').selectpicker(
            );
        });

        $(function () {
            $('#txtIzinSebepAdded').selectpicker(
            );
        });

        var table = $('#DTIzinListesi').DataTable({
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
                    // Çıktının hangi kolonlarının görünür olması için
                    exportOptions: {
                        columns: [0, 1, 2, 3, 4, 5, 6, 7]
                    },
               ");
            WriteLiteral(@"     // Çıktının dosya ismi
                    title: 'Personel Listesi ' + gun + '-' + (ay + 1) + '-' + yil + '__' + saat + ':' + dakika + ':' + saniye,
                    text: 'Excel'
                },
                // Kaçlı listeler halinde görünsün
                { extend: 'pageLength', text: 'Görüntülenme' },
                // PDF olarak çıktı al
                // PDF olarak çıktı al
                {
                    // Çıktının tipi
                    extend: 'pdf',
                    // Çıktının hangi kolonlarının görünür olması için
                    exportOptions: {
                        columns: [0, 1, 2, 3, 4, 5, 6, 7]
                    },
                    // Çıktının dosya ismi
                    title: 'Personel Listesi ' + gun + '-' + (ay + 1) + '-' + yil + '__' + saat + ':' + dakika + ':' + saniye,
                    orientation: 'landscape',
                },
                // Sütunlardan hangisi görünsün
                { extend: 'colvis', text:");
            WriteLiteral(@" 'Sütun Gizle/Göster' }],
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
            // columnDef özelliğini açar olarak anladım.
            rowReorder: true,
            //");
            WriteLiteral(@" Targets olarak seçtiğin indeks sıralamasına göre sütunların order özelliği açılır kapanır.
            columnDefs: [
                { width: '4%', targets: 0 },
                { searchable: true, orderable: true, className: 'reorder', targets: [1] },
                { searchable: false, orderable: false, targets: '_all' }
            ],
            ""scrollX"": true,
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
        $(""#listPersonelAnaBaslik"").attr('class', 'nav-item activ");
            WriteLiteral(@"e');
        // Menünün tüm alt başlıklarını açık tutmak için
        $(""#personelMenusu"").attr('class', 'collapse show');
        // Seçilen alt başlığın baskın olması için
        $(""#izinButonu"").attr('class', 'collapse-item active');
        // Seçildiğinde okun aşağı doğru bakması için
        $(""#personelOkYonu"").toggleClass('collapsed');

        

    });

    function AddedIzinModalReflesh() {
        $(""#txtIzinPersonelAdded"").selectpicker('val', null);
        $(""#txtIzinSebepAdded"").selectpicker('val', null);
        $(""#txtIzinBaslangicTarihi"").val(null);
        $(""#txtIzinBitisTarihi"").val(null);
    }
</script>

<!-- #endregion -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IzinMazeretViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591