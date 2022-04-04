let selectedIds = {}
for (let s of document.getElementsByClassName('player-select')) {
    selectedIds[s.id] = s.value;

    if (s.value) {
        updateSelectedIds(s);
    }

    s.addEventListener('change', function () {
        updateSelectedIds(s);
    });
}

function updateSelectedIds(s) {
    for (let other of document.getElementsByClassName('player-select')) {
        if (other != s) {
            for (let option of other.options) {
                if (option.value == s.value) {
                    option.disabled = true;
                } else if (option.value == selectedIds[s.id]) {
                    option.disabled = false;
                }
            }
        }
    }
    selectedIds[s.id] = s.value;
}
