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

document.querySelector("#searchBox").addEventListener("keyup", event => {
    if (event.key !== "Enter") return; 
    document.querySelector("#searchButton").click(); 
    event.preventDefault();
});