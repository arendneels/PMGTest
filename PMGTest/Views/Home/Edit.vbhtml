@Code
    ViewData("Title") = "Edit"
    Layout = "~/Views/Shared/_Layout.vbhtml"
    Dim lang = ViewData("lang")
End Code

<div class="container" style="justify-content:center;">
    <form action="/@lang/tegels/edit/@ViewData("tiles")(0).id" method="post" style="display:flex; flex-direction:column">
        <h2>Edit tile</h2>
        @Code
            'Show data for all languages
            Dim tiles = ViewData("tiles")
            For Each tile As Tile In tiles
                @<label>@tile.lang.ToUpper</label>
                @<input type="text" name="@tile.lang" value="@tile.name" />
            Next
        End Code
        <label>Color</label>
        <select id="color-select" name="color_id">
            @Code
                'Show all colors as options
                Dim colors = ViewData("Colors")
                Dim tileColor = ViewData("tiles")(0).color_hex
                For Each color As Color In colors
                    Dim selectedOption = ""
                    If color.hex = tileColor Then
                        selectedOption = "selected"
                    End If

                    @<option style="margin:3px; width:100%; height:100%; background:@color.hex" value="@color.id" @selectedOption></option>
                Next
            End Code
        </select>
        <input type="submit" name="submit" value="Edit" />
    </form>
</div>
