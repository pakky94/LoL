let selectedLegends = {}
for (let s of document.getElementsByClassName('legend-select')) {
    selectedLegends[s.id] = s.value;

    if (s.value) {
        updateSelectedLegends(s);
    }

    s.addEventListener('change', function () {
        updateSelectedLegends(s);
    });
}

function updateSelectedLegends(s) {
    for (let other of document.getElementsByClassName('legend-select')) {
        if (other != s) {
            for (let option of other.options) {
                if (option.value == s.value) {
                    option.disabled = true;
                } else if (option.value == selectedLegends[s.id]) {
                    option.disabled = false;
                }
            }
        }
    }
    selectedLegends[s.id] = s.value;
}

let selectedTeams = {}
for (let s of document.getElementsByClassName('team-select')) {
    selectedTeams[s.id] = s.value;

    if (s.value) {
        updateSelectedTeams(s);
    }

    s.addEventListener('change', function () {
        updateSelectedTeams(s);
    });
}

function updateSelectedTeams(s) {
    for (let other of document.getElementsByClassName('team-select')) {
        if (other != s) {
            for (let option of other.options) {
                if (option.value == s.value) {
                    option.disabled = true;
                } else if (option.value == selectedTeams[s.id]) {
                    option.disabled = false;
                }
            }
        }
    }
    selectedTeams[s.id] = s.value;
}
