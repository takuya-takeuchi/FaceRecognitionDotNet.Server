var canvas;
var context;
var img = new Image();

function draw_detect_result(base64, areas)
{
    canvas = document.getElementById("SrcCanvas");
    context = canvas.getContext("2d");

    img.onload = function ()
    {
        canvas.width = img.width;
        canvas.height = img.height;
        context.drawImage(img, 0, 0);

        length = areas.length;
        for (var index = 0; index < length; index++)
        {
            area = areas[index];
            x = area.x;
            y = area.y;
            w = area.width;
            h = area.height;

            context.strokeStyle = 'rgb(255, 0, 0)';                     
            context.lineWidth = 5;

            context.beginPath();

            // lt to rt
            context.moveTo(x, y);
            context.lineTo(x + w, y);

            // rt to rb
            context.lineTo(x + w, y + h);

            // rb to lb
            context.lineTo(x    , y + h);

            // lb to lt
            context.lineTo(x, y);
            context.lineTo(x + w, y);

            context.stroke();
            context.closePath();
        }
    }

    img.src = base64;
}
