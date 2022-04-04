let winnerSelect = document.getElementById('winner-select');

document.getElementById('team-select-1').addEventListener('change', function () {
	winnerSelect.options[1].hidden = false;
	winnerSelect.options[1].value = this.value;
	winnerSelect.options[1].innerHTML = this.options[this.selectedIndex].text;
});

document.getElementById('team-select-2').addEventListener('change', function () {
	winnerSelect.options[2].hidden = false;
	winnerSelect.options[2].value = this.value;
	winnerSelect.options[2].innerHTML = this.options[this.selectedIndex].text;
});