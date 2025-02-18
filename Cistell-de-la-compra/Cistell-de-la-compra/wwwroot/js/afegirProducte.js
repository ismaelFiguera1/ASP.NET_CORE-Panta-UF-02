const d = document;

d.addEventListener("DOMContentLoaded", () => {
    const $afegir = d.querySelector("#ap");
    const $carret = d.querySelector("#carretCompra");
    $afegir.addEventListener("click", (e) => {
        e.preventDefault();
        let url = $afegir.getAttribute("href");
        $carret.classList.add("hidden");
        const $modal = d.querySelector("#afegirModal");
        const modelBootstrap = new bootstrap.Modal($modal);
        const $contingut = d.querySelector(".modal-body");


        $.ajax({
            url: url,
            type: "GET",
            success: (response) => {
                console.log(response);
                $contingut.innerHTML = response;

                modelBootstrap.show();
            },
            error: (err) => {
                console.log(err);
            }
        })
    })
})