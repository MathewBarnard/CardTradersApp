// Globals
var cardsInDeck = [];

$(document).ready(function () {

    $('#saveChangesButton').click(function () {
        save();
    });

    $('#searchTerm').on('input', function () {
        refreshWithResults();
    });

    console.log("Page loaded!");
});

function refreshWithResults() {

    console.log("Refreshing page.");

    $('.cardSearchRow').hover(
        function () {
        var name = $(this).attr('name');
        showPicture($(this));
    },
        function () {
            var name = $(this).attr('name');
            hidePicture($(this));
    });

    $(".addCardButton").click(function () {
        updateDeckView($(this).attr('name'));
        cardsInDeck.push($(this).attr('name'));
    });

    $(".removeCardButton").click(function () {

        var card = $.inArray($(this).attr('name'), cardsInDeck);

        if (card != -1) {
            cardsInDeck.splice(card, 1);
            console.log(cardsInDeck);
        }
    })
}

function save() {
    console.log("Saving deck");
    $.ajax({
        url: '/Decks/Save?deck=' + JSON.stringify(cardsInDeck),
        data: {},
        type: "POST",
        contentType: "application/json",
        success: function (data) {
            result = data;
        }
    });
}

function updateDeckView(name) {

    var card = $.inArray(name, cardsInDeck);

    if (card == -1) {
        $('#deckTable').append("<tr class='card-row' name='" + name + "'><td>" + name + "</td><td class='cardQuantity'>x1</td></tr>")
    }
    else {
        var count = 1;

        for (var i = 0; i < cardsInDeck.length; i++) {
            if (cardsInDeck[i] == name) {
                count = count + 1;
            }
        }

        if (count <= 4) {
            $("tr[name='" + name + "']").find('.cardQuantity').html('x' + count);
        }
    }
}

function showPicture(element) {
    var name = $(element).attr('name');

    var newElement = $('<img class="cardThumbnail" src="http://www.mathewbarnard.co.uk/images/' + name + '.full.jpg">');

    $(element).append(newElement)
}

function hidePicture(element) {
    $(element).find('img').remove();
}