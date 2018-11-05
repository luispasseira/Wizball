// ----------------------------------------------------------------------------------------------------------------
// --- MatchesTipsGrid resizing                                                                                
// ----------------------------------------------------------------------------------------------------------------
window.addEventListener("resize", setMatchesTipsGridHeight);   // Adds an event listener to the window resize event. This ways we can reset matchesTipsGrid height whenever the user changes window size.

function setMatchesTipsGridHeight() {                                       // Function containing the logic on how the gridMatchesGrid should resize it self to fit the current browser window.                               

    if (window.innerWidth >= 960) {

        currentGridBodyHeight   = getCurrentGridBodyHeight();               // Gets the real current grid body height. 
        availableGridBodyHeight = getAvailableGridBodyHeight();             // Gets the available grid body height. 

        if (currentGridBodyHeight < availableGridBodyHeight) {
            document.getElementById("grid-body-scrollable").setAttribute("style", "height:" + currentGridBodyHeight + "px;");
        }
        else {
            document.getElementById("grid-body-scrollable").setAttribute("style", "height:" + availableGridBodyHeight + "px;");
        }

    }
}
function getCurrentGridBodyHeight() {

    var rowsCounter = 0;                                            
    var rows = document.getElementById("grid-body").childNodes;     // Gets all rows inside matchesTipsGrid.

    for (var i = 0; i < rows.length; i++) {                         // For each one.
        if (rows[i].style.display !== "none") {                     // Check if it is visible.
            rowsCounter++;                                          // And increases rowsCounter
        }
    }

    return rowsCounter * 30;                                        // Finally return the number of visible rows * 30. (Current matchesTipsGrid body height).
}
function getAvailableGridBodyHeight() {

    var windowHeight        = parseInt(window.innerHeight);                 // Gets window height (Total height space available).
    var navbarHeight        = parseInt($("#app-header").height());          // Gets the navbarHeight.
    var competitionsFilters = parseInt($("#filters").outerHeight());        // Gets the competitions filters height.
    var gridHeader          = parseInt($("#grid-header").outerHeight());    // Sets matchesTipsGrid header height.
    var gridPadding         = 100;                                          // Hardcoded padding for matchesTipsGrid.


    var availableGridBodyHeight = windowHeight - navbarHeight - competitionsFilters - gridHeader - gridPadding;     // Total available height for matchesTipsGrid body.


    while (availableGridBodyHeight % 30 !== 0) {                                                                    // This small step will ensure the the gridBodyHeight is divisible by 30.
        availableGridBodyHeight--;                                                                                  // 30px is the size of individual rows. 
    }

    return availableGridBodyHeight;
}




// ----------------------------------------------------------------------------------------------------------------
// --- MatchesTipsGrid competitions filters                                                                    
// ----------------------------------------------------------------------------------------------------------------
document.getElementById("filters").addEventListener("click", function (e) {                             // Adds event listener to the div containing all the competitions filters options.

    if (e.target && (e.target.id === "show-all-outter" || e.target.id === "show-all")) {                // If user selects show all competitions "btn".

        showAllRows();                                                                                  // Calls showAllRows() which will select all competitions as well showing up all matchesTipsGrid rows.
        setMatchesTipsGridHeight();                                                                     // Finally because the visible number of rows in MatchesTipsGrid may changed we need to reset its height.

        resetRowsColors();
    }
    else if (e.target && (e.target.id === "show-none-outter" || e.target.id === "show-none")) {         // If user selects hide all competitions "btn".

        hideAllRows();                                                                                  // Calls hideAllRows() which will deselect all competitions as well hiding all matchesTipsGrid rows.
        setMatchesTipsGridHeight();                                                                     // Finally because the number of rows in MatchesTipsGrid may changed we need to reset its height.

        resetRowsColors();
    }
    else if (e.target && e.target.nodeName === "DIV") {                                                 // If user selects one of the others child divs inside the parent div Filters.

        var div = document.getElementById(e.target.id);                                                 // Gets the element.                                                  

        if (div.classList.contains("competition")) {                                                    // If the element has the class named "competition" then we know that is a valid div to be evaluated.

            div.classList.toggle("unselected");                                                         // Toggle the class unselected. This will deselect this particular competition in case it is selected,
                                                                                                        // Or select it in case it is deselected.
            filterRowsByCompetitions();                                                                 // Then call filterByCompetition() which will filter the matchesTipsGrid accordingly to the user competition selection/deselection.

            setMatchesTipsGridHeight();                                                                 // Finally because the visible number of rows in MatchesTipsGrid may changed we need to reset its height.

            resetRowsColors();
        }

    }
    else if (e.target && e.target.nodeName === "IMG") {                                                 // If user selects one of the others child imgs inside the parent div Filters.

        document.getElementById(e.target.id).parentElement.classList.toggle("unselected");              // Gets the particular img parent div which is always a competition.
                                                                                                        // Then we can be sure we can toggle the class named "unselected". 
                                                                                                        // This will deselect this particular competition in case it is selected, or select it in case it is deselected.

        filterRowsByCompetitions();                                                                     // Then call filterByCompetition() which will filter the matchesTipsGrid accordingly to the user competition selection/deselection.

        setMatchesTipsGridHeight();                                                                     // Finally because the visible number of rows in MatchesTipsGrid may changed we need to reset its height.

        resetRowsColors();
    }

});

function filterRowsByCompetitions() {

    var children = document.getElementById("filters").childNodes;       // Gets all childrens in filters div (We need all competitions div elements which contains needed info).                          

    for (var i = 1; i < children.length; i++) {                         // For each item except the first one (which is not a competition instead is the div options).

        compId = children[i].getAttribute("id");                        // Gets the attribute Id for the current child item (competition) which will be needed for the next step.

        if (children[i].classList.contains("unselected")) {             // If current child item (competition) has a class named "unselected" then.
            hideRowsByCompetition(compId);                              // Hides all rows which belongs to the respective competition id.
        }
        else {
            showRowsByCompetition(compId);                              // Shows all rows which belongs to the respective competition id.
        }
    }

}
function showRowsByCompetition(competitionId) {

    var gridRows = document.getElementById("grid-body").childNodes;         // Gets all rows in matchesTipsGrid table.

    for (var i = 0; i < gridRows.length; i++) {                             // For each one of the rows.

        if (gridRows[i].getAttribute("compid") === competitionId) {         // Check if the current row has the attribute compId equals to the parameter competitionId.
            gridRows[i].style.display = "flex";                             // And then change its state from display:none to display:flex.
        }
    }

}
function hideRowsByCompetition(competitionId) {

    var gridRows = document.getElementById("grid-body").childNodes;         // Gets all rows in matchesTipsGrid table.

    for (var i = 0; i < gridRows.length; i++) {                             // For each one of the rows.

        if (gridRows[i].getAttribute("compid") === competitionId) {         // Check if the current row has the attribute compId equals to the parameter competitionId.
            gridRows[i].style.display = "none";                             // And then change its state from display:flex to display:none.
        }
    }

}

function showAllRows() {

    var gridRows = document.getElementById("grid-body").childNodes;         // Gets all rows in matchesTipsGrid table.

    for (var i = 0; i < gridRows.length; i++) {                             // For each one of the rows.
        gridRows[i].style.display = "flex";                                 // Change its state to display:flex.
    }


    var filters = document.getElementById("filters").childNodes;            // Gets all childrens in filters div.

    for (i = 1; i < filters.length; i++) {                                  // For each item except the first one (which is not a competition instead is the div options).
        filters[i].classList.remove("unselected");                          // Removes class named unselected.
    }
}
function hideAllRows() {

    var gridRows = document.getElementById("grid-body").childNodes;         // Gets all rows in matchesTipsGrid table.

    for (var i = 0; i < gridRows.length; i++) {                             // For each one of the rows.
        gridRows[i].style.display = "none";                                 // Change its state to display:none.
    }


    var filters = document.getElementById("filters").childNodes;            // Gets all childrens in filters div.

    for (i = 1; i < filters.length; i++) {                                  // For each item except the first one (which is not a competition instead is the div options).
        filters[i].classList.add("unselected");                             // Adds class named unselected.       
    }
}




// ----------------------------------------------------------------------------------------------------------------
// --- MatchesTipsGrid columns sorting                                                                    
// ----------------------------------------------------------------------------------------------------------------
// Easy to handle grid pointer.
var table = document.getElementById("grid-body");
// Easy to handle grid rows pointer.
var rows = document.getElementById("grid-body").childNodes;
// General purposes variables
var date_i, date_j, ftotahg_j, ftotahg_i, comp_j, comp_i, i, index;

// Easy to handle grid columns pointers.
var headerCellDate = document.getElementById("header-cell-date");
var headerCellFtotahg = document.getElementById("header-cell-ftotahg");
var headerCellCompetitions = document.getElementById("header-cell-competitions");

// Columns sorting state arrows
var dateSortingArrow = headerCellDate.querySelector("I");
var FtotahgSortingArrow = headerCellFtotahg.querySelector("I");
var CompetitionsSortingArrow = headerCellCompetitions.querySelector("I");

// Columns initial sorting states.
var dateSorting         = "desc";
var ftotahgSorting      = "desc";
var competitionsSorting = "asc";


headerCellCompetitions.addEventListener("click", function () {

    dateSortingArrow.style.color = "transparent";                    // Sets header-cell-date arrow to transparent.
    FtotahgSortingArrow.style.color = "transparent";                    // Sets header-cell-ftotahg arrow to transparent. 
    CompetitionsSortingArrow.style.color = "#9acd32";                        // Sets header-cell-competitions to visible. 


    CompetitionsSortingArrow.classList.toggle("fa-long-arrow-alt-up");          // Toggles sorting icon.
    CompetitionsSortingArrow.classList.toggle("fa-long-arrow-alt-down");


    if (competitionsSorting === "desc") {                                                                           // Sorts columns accordingly.

        sortCompetitionsAsc();
        competitionsSorting = "asc";

    }
    else if (competitionsSorting === "asc") {

        sortCompetitionsDesc();
        competitionsSorting = "desc";

    }

    resetRowsColors();

});
function sortCompetitionsAsc() {

    console.time("Sorting Comp Asc");
    sortTableAsc("compid");
    console.timeEnd("Sorting Comp Asc");

}
function sortCompetitionsDesc() {

    console.time("Sorting Comp Desc");
    sortTableDesc("compid");
    console.timeEnd("Sorting Comp Desc");
}

headerCellDate.addEventListener("click", function () {

    dateSortingArrow.style.color = "#9acd32";                        // Sets header-cell-competitions to visible. 
    FtotahgSortingArrow.style.color = "transparent";                    // Sets header-cell-ftotahg arrow to transparent.  
    CompetitionsSortingArrow.style.color = "transparent";                    // Sets header-cell-competitions arrow to transparent.


    dateSortingArrow.classList.toggle("fa-long-arrow-alt-up");                  // Toggles sorting icon.
    dateSortingArrow.classList.toggle("fa-long-arrow-alt-down");


    if (dateSorting === "desc")                                                 // Sorts columns accordingly.
    {
        sortDateAsc();
        dateSorting = "asc";
    }
    else if (dateSorting === "asc") {

        sortDateDesc();
        dateSorting = "desc";
    }

    resetRowsColors();

});
function sortDateAsc() {

    console.time("Sorting Date Asc");
    sortTableAsc("dateTime");
    console.timeEnd("Sorting Date Asc");

}
function sortDateDesc() {
    console.time("Sorting Date Desc");
    sortTableDesc("dateTime");
    console.timeEnd("Sorting Date Desc");
}

headerCellFtotahg.addEventListener("click", function () {

    dateSortingArrow.style.color = "transparent";                        // Sets header-cell-competitions to transparent. 
    FtotahgSortingArrow.style.color = "#9acd32";                            // Sets header-cell-ftotahg arrow to visible.    
    CompetitionsSortingArrow.style.color = "transparent";                        // Sets header-cell-competitions arrow to transparent.


    FtotahgSortingArrow.classList.toggle("fa-long-arrow-alt-up");                   // Toggles sorting icon.
    FtotahgSortingArrow.classList.toggle("fa-long-arrow-alt-down");


    if (ftotahgSorting === "desc")                                                  // Sorts columns accordingly.
    {
        sortFtotahgAsc();
        ftotahgSorting = "asc";
    }
    else if (ftotahgSorting === "asc") {

        sortFtotahgDesc();
        ftotahgSorting = "desc";
    }

    resetRowsColors();

});
function sortFtotahgAsc() {

    console.time("Sorting Tip 2.5 Asc");
    sortTableAsc("ftotahg");
    console.timeEnd("Sorting Tip 2.5 Asc");

}
function sortFtotahgDesc() {

    console.time("Sorting Tip 2.5 Desc");
    sortTableDesc("ftotahg");
    console.timeEnd("Sorting Tip 2.5 Desc");

}

// ----------------------------------------------------------------------------------------------------------------
// --- Bubble sort                                                                
// ----------------------------------------------------------------------------------------------------------------
function sortTableAsc(column) {

    for (var i = 0; i < rows.length - 1; i++) {

        minIndex = i;

        for (var j = i + 1; j < rows.length; j++) {

            if (rows[j].getAttribute(column) < rows[minIndex].getAttribute(column)) {
                minIndex = j;
            }
        }

        table.insertBefore(rows[minIndex], rows[i]);
    }
}
function sortTableDesc(column) {

    for (var i = 0; i < rows.length - 1; i++) {

        minIndex = i;

        for (var j = i + 1; j < rows.length; j++) {

            if (rows[j].getAttribute(column) > rows[minIndex].getAttribute(column)) {
                minIndex = j;
            }
        }

        table.insertBefore(rows[minIndex], rows[i]);
    }
}




// ----------------------------------------------------------------------------------------------------------------
// --- MatchesTipsGrid reset row colors                                                                   
// ----------------------------------------------------------------------------------------------------------------
function resetRowsColors() {

    var rows = document.getElementById("grid-body").childNodes;

    var oddEven = 0;
    for (var i = 0; i < rows.length; i++) {
        if(rows[i].style.display === "flex")
        {
            if (oddEven === 0) {
                rows[i].style.backgroundColor = "#f2f2f2";
                oddEven = 1;
            }
            else {
                rows[i].style.backgroundColor = "#fff";
                oddEven = 0;
            }          
        }
    }
}




// ----------------------------------------------------------------------------------------------------------------
// --- MatchesTipsGrid utc_date to client date                                                                                
// ----------------------------------------------------------------------------------------------------------------
const monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun",
    "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
];
function convertUtcDateToLocalDate() {

    var cells = document.querySelectorAll('.grid-body > .grid-row > #utc-date');

    for (var i = 0; i < cells.length; i++) {


        var mil = parseFloat(cells[i].getAttribute("utc-date"));

        var datex = new Date(mil);

        var month, day, hour, minute;



        month = monthNames[datex.getMonth()];

        day = ("0" + datex.getDate()).slice(-2);

        hour = ("0" + datex.getHours()).slice(-2);

        minute = ("0" + datex.getMinutes()).slice(-2);

        cells[i].innerHTML = day + " " + month + " " + hour + ":" + minute;
    }

}




// ----------------------------------------------------------------------------------------------------------------
// --- On view load executions                                                                
// ----------------------------------------------------------------------------------------------------------------
window.addEventListener("load", function () {
    convertUtcDateToLocalDate();
    setMatchesTipsGridHeight();
});