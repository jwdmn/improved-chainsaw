function getSearchResults() {
    $.ajax({
        url: "/TvShow/Search",
        type: "GET",
        data: { "searchQuery": $("#searchBox").val() },
        success: function (result) {
            console.log(result);
            $("#searchResultsExpander").html(result);
        }
    });
}