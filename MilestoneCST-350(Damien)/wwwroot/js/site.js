// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    // The mouse down event - is needed to sense
    //which mouse button is actually clicked
    $(document).on("mousedown", ".game-button", function (event)
    {
        event.preventDefault();
        switch (event.which) {
            // Left mouse button
            case 1:
                var buttonNumber = $(this).val();   
                handleLeftClick(buttonNumber)
                console.log("Button number " + buttonNumber + " was left clicked.")
                break;
            // Middle mouse button
            case 2:
                alert("Middle mouse button clicked");
                break;
            // Right mouse click
            case 3:
                var buttonNumber = $(this).val();
                handleRightClick(buttonNumber)
                console.log("Button number " + buttonNumber + " was right clicked.")
                break;
            default:
                alert("nothing");
        }
    });

    // Bind a new event to the context menu to prevent the right-click
    // from appearing on the page.
    // whenever the context menu shows up call this function
    $(document).bind("contextmenu", function (event) {
        // Stop the right click from showing the context menu
        event.preventDefault();
        console.log("Right click...Prevent context menu..")
    });

    function handleLeftClick(clickedCell)
    {
        $.ajax({
            datatype: "json",
            method: "POST",
            url: 'Minesweeper/LoadUpdatedBoard_WhenLeftClick',
            data:
            {
                "clickedCell": clickedCell
            },
            success: function (data) {
                console.log(data);
                $("#game-board").html(data);
            }
        });
    }

    function handleRightClick(clickedCell) {
        $.ajax({
            datatype: "json",
            method: "POST",
            url: 'Minesweeper/LoadUpdatedBoard_WhenRightClick',
            data:
            {
                "clickedCell": clickedCell
            },
            success: function (data) {
                console.log(data);
                $("#game-board").html(data);
            }
        });
    }

});



