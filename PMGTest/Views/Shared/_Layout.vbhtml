<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!--STYLES-->
    @Styles.Render("~/Styles/style.css")
    @Styles.Render("~/Styles/jquery-ui.min.css")

    <title>PMG Test</title>
</head>

<body>
    <h1 id="title">PMG Test</h1>
    <!--CONTENT-->
    @RenderBody

    <!--SCRIPTS-->
    @Scripts.Render("~/Scripts/jquery.min.js")
    @Scripts.Render("~/Scripts/jquery-ui.min.js")
    @Scripts.Render("~/Scripts/script.js")
    @RenderSection("scripts", required:=False)
</body>
</html>
