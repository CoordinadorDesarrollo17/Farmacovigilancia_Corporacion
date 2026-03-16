function includeHTML(id, url, callback) {
    fetch(url)
        .then((res) => res.text())
        .then((html) => {
            document.getElementById(id).innerHTML = html;
            if (callback) callback();
        });
}

// Subrayado activo en navbar (clic y scroll)
function activarSubrayadoNavbar() {
    // Al hacer clic
    document.querySelectorAll('.navbar-nav .nav-link').forEach(function (link) {
        link.addEventListener('click', function () {
            document.querySelectorAll('.navbar-nav .nav-link').forEach(function (nav) {
                nav.classList.remove('active');
            });
            this.classList.add('active');
        });
    });

    // Al hacer scroll
    window.addEventListener('scroll', function () {
        const sections = ['top', 'nosotros', 'certificaciones', 'contacto'];
        let current = 'top';
        for (const id of sections) {
            const section = document.getElementById(id);
            if (section && section.getBoundingClientRect().top <= 120) {
                current = id;
            }
        }
        document.querySelectorAll('.navbar-nav .nav-link').forEach(function (link) {
            link.classList.remove('active');
            if (link.getAttribute('href') === '#' + current) {
                link.classList.add('active');
            }
        });
    });
}
//// Incluir cabecera y activar scripts dependientes del menú
//includeHTML("header-include", "header.html", activarSubrayadoNavbar);
//includeHTML("footer-include", "footer.html", activarSubrayadoNavbar);

(function () {
    const inputBusqueda = document.getElementById('busquedaProducto');
    const selectOrden = document.getElementById('ordenarProducto');
    const lista = document.getElementById('listaProductos');

    if (inputBusqueda && lista) {
        inputBusqueda.addEventListener('input', function () {
            const texto = this.value.toLowerCase();
            const productos = document.querySelectorAll('#listaProductos .producto-card');
            productos.forEach(card => {
                const contenido = card.textContent.toLowerCase();
                card.parentElement.style.display = contenido.includes(texto) ? '' : 'none';
            });
        });
    }

    if (selectOrden && lista) {
        selectOrden.addEventListener('change', function () {
            const valor = this.value;
            const items = Array.from(lista.querySelectorAll('.col'));

            items.sort((a, b) => {
                const nombreA = a.querySelector('.fw-bold').textContent.trim().toLowerCase();
                const nombreB = b.querySelector('.fw-bold').textContent.trim().toLowerCase();
                if (valor === 'nombre') {
                    return nombreA.localeCompare(nombreB);
                } else if (valor === 'nombreDesc') {
                    return nombreB.localeCompare(nombreA);
                }
                return 0;
            });

            items.forEach(item => lista.appendChild(item));
        });
    }
})();

function validarDigitosCelular(valor, id) {
    let reg = /^([0-9])*$/;

    if (valor.match(reg)) {
        if (valor.length >= 9) {
            $(`#${id}`).val(valor.slice(0, 9));
        }
    } else {
        $(`#${id}`).val('');
    }
}

$('.cls-numeric').keypress(function (tecla) {
    if (tecla.charCode < 48 || tecla.charCode > 57) {
        return false;
    }
});