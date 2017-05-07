// Globals
var cardsInDeck = [];

$(document).ready(function () {

    $('#saveChangesButton').click(function () {
        save();
    });

    console.log("Page loaded!");
});

function refreshWithResults() {

    console.log("Refreshing page.");

    $(".addCardButton").click(function () {
        cardsInDeck.push($(this).attr('name'));
        console.log(cardsInDeck);
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