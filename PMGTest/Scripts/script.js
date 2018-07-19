$(function () {
    //Set initial select color
    var color = $("#color-select").find(":selected").css('background');
    $("#color-select").css('background', color);

  //Select color
    $('#color-select').click(function () {
        var color = $(this).find(":selected").css('background');
        $(this).css('background', color);
    });

  //Draggable config
    $(".tile").draggable({
      stop: function( event, ui ) {
        //Reset position
        $(this).css({
            'left': '',
            'top' : '',
            'z-index': ''
        });
      },

      drag: function( event, ui ) {
        //Dragged object always on top
        $(this).css('z-index', '1000');
      }
    });

    //Droppable config
    $(".tile").droppable({
      drop: function( event, ui ) {
        var orderDraggable = ui.draggable.css('order');
        var orderDroppable = $(this).css('order');
        //Send ajax request to save order -Work in progress!
          var data = [
              {
                  id: ui.draggable.attr('id'),
                  new_order: orderDroppable
              },
              {
                  id: $(this).attr('id'),
                  new_order: orderDraggable
              }
          ];
          console.log(data);
          jsonData = JSON.stringify(data);
          console.log(jsonData);
          $.ajax({
              type: "POST",
              url: "/Home/changeorder",
              data: jsonData,
              success: function (result) {
                  console.log(result);
              }
          });

        //Change order
        ui.draggable.css('order', orderDroppable);
        $(this).css('order', orderDraggable);
      }
    });
});


