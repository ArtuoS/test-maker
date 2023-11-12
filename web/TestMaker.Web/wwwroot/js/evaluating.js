document.addEventListener('DOMContentLoaded', function () {
    const checkboxes = document.querySelectorAll('input[type="checkbox"]');
    checkboxes.forEach(function (checkbox) {
        checkbox.addEventListener('change', function () {
            if (this.checked) {
                const groupName = this.getAttribute('name');
                checkboxes.forEach(function (otherCheckbox) {
                    if (otherCheckbox !== checkbox && otherCheckbox.getAttribute('name') === groupName) {
                        otherCheckbox.checked = false;
                    }
                });
            }
        });
    });

    var searchButtons = document.querySelectorAll('.search-button');
    searchButtons.forEach(function (searchButton) {
        searchButton.addEventListener('click', function () {
            var question = searchButton.getAttribute("question");
            var website = searchButton.getAttribute("website");
            var rawQuestion = document.getElementById(`formatted-question-${question}`).innerHTML;
            if (website) rawQuestion = `site: ${website} ${rawQuestion}`;
            var googleSearchURL = "https://www.google.com/search?q=" + encodeURIComponent(rawQuestion);
            window.open(googleSearchURL, '_blank');
        });
    });

    var extractButton = document.querySelector('.extract');
    extractButton.addEventListener('click', function () {
        var selectedAnswers = document.querySelectorAll('.question-checkbox:checked');
        selectedAnswers.forEach((v, k) => {
            var question = document.getElementById(v.name.replace("question-", ""));
            var text = question.getAttribute("data-question-index");
            text += " ->" + v.parentNode.innerText;
            console.log(text);
        })
    });
});