// izvršava nakon što glavni html dokument bude generisan
$(document).ready(function () {

    // Funkcija za ucitavanje view-a sa proizvodima i stavkama
    // Prima kategorija ID zbog ucitavanja proizvoda te kategorije
    // Prima narudzba ID zbog povezanosti stavki i narudzbe
    function UcitajStavkeDiv(KategorijaId, NarudzbaId) {
        var url = "/ModulRestoran/StavkeRacuna/PrikaziStavke?" +
            "KategorijaId=" + KategorijaId +
            "&NarudzbaId=" + NarudzbaId;

        $.get(url, function (data, status) {
            stavkeDiv.html(data);
        });
    }

    // Ajax poziv za automatsko ucitavanje stavkeDiv u akciji UrediNarudzbu
    var stavkeDiv = $('#stavkeDiv');
    if (stavkeDiv.length) { // ukoliko stavkeDiv postoji na stranici
        var KategorijaId = stavkeDiv.attr('kategorija-id');
        var NarudzbaId = stavkeDiv.attr('narudzba-id');

        UcitajStavkeDiv(KategorijaId, NarudzbaId);
    }

    // Event koji reaguje na promjenu vrijednosti dropdowna
    // Nakon promjene osvjezava stavkeDiv sa ucitanim proizvodima iz odabrane kategorije
    $(document).on('change', '#KategorijaDropdown', function () {
        var KategorijaId = $(this).val(); // get ID odabrane kategorije
        var NarudzbaId = stavkeDiv.attr('narudzba-id');
        UcitajStavkeDiv(KategorijaId, NarudzbaId);
    });







});