@Code
    Dim page = ViewData("page")
    Dim lang = ViewData("lang")
    Dim previousPage = page - 1
    Dim nextPage = page + 1
    Dim tileCount = ViewData("TileCount")
End Code


<div class="container" style="justify-content: flex-end">
    <p style="padding-right: 36px;">
        <a href="/nl/tegels/@page">NL</a> / 
        <a href="/en/tegels/@page">EN</a> / 
        <a href="/fr/tegels/@page">FR</a>
    </p>
</div>

<div class="container">
    @Code
        Dim tiles = ViewData("Tiles")
        For Each tile As Tile In tiles
            @<a id="@tile.id" href="/@lang/tegels/edit/@tile.id" class="tile" style="order: @tile.order; background-color: @tile.color_hex"><strong>@tile.name</strong></a>
        Next
    End Code
</div>

<div style="display:block; margin: 0px auto; max-width:1100px">
    @Code
        If previousPage > 0 Then
            @<a href="/@lang/tegels/@previousPage" style="margin-left: 38px">Previous</a>
        Else
            @<a href="#" style="margin-left: 38px"></a>
        End If

        If tileCount > page * 12 Then
            @<a href = "/@lang/tegels/@nextPage" style="float:right; margin-right: 38px">Next</a>
        End If

    End Code
</div>

<div class="container" style="justify-content:center;">
    <form action="/Home/Create" method="post" style="display:flex; flex-direction:column">
        <h2>Add new tile</h2>
        <label>NL</label>
        <input type="text" name="nl" value="" />
        <label>EN</label>
        <input type="text" name="en" value="" />
        <label>FR</label>
        <input type="text" name="fr" value="" />
        <label>Color</label>
        <select id="color-select" name="color_id">
            @Code
                Dim colors = ViewData("Colors")
                For Each color As Color In colors
                    @<option style="margin:3px; width:100%; height:100%; background:@color.hex" value="@color.id"></option>
                Next
            End Code
        </select>
        <input type="submit" name="submit" value="Submit" />
    </form>
</div>