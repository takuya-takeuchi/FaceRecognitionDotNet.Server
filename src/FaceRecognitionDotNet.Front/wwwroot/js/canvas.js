var canvas;
var context;
var img = new Image();

function canvas_init(base64)
{
    canvas = document.getElementById("SrcCanvas");
    context = canvas.getContext("2d");

    img.onload = function ()
    {
        canvas.width = img.width;
        canvas.height = img.height;
        context.drawImage(img, 0, 0);
    }

    img.src = base64;
}
