$("#btn-create-package").click(function() {

var products = $(".add-product");
var productIds = [];
var packageName = $("#package-name").val();
var packagePrice = $("#package-price").val();
$.each(products, function(index, item) {
if ($(item).prop('checked')) {
productIds.push($(item).attr('name'));
}
})
console.log(productIds);

$.ajax({
    url: "/Package/CreatePackage",
    type: "POST",
    data: { productIds:productIds,
    packageName:packageName,
    packagePrice:packagePrice },
    success: function (data)
        {
         location.reload();
        }
    });
})