<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="InicioUser.aspx.cs" Inherits="ProyectoPetVida.Usuario.InicioUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <center>
        <style>
            * {box-sizing: border-box}
            body {font-family: Verdana, sans-serif; margin:0}
            .mySlides {display: none}
            img {vertical-align: middle;}
            
            /* Slideshow container */
            .slideshow-container {
              max-width: 1000px;
              position: relative;
              margin: auto;
            }
            
            /* Next & previous buttons */
            .prev, .next {
              cursor: pointer;
              position: absolute;
              top: 50%;
              width: auto;
              padding: 16px;
              margin-top: -22px;
              color: white;
              font-weight: bold;
              font-size: 18px;
              transition: 0.6s ease;
              border-radius: 0 3px 3px 0;
              user-select: none;
            }
            
            /* Position the "next button" to the right */
            .next {
              right: 0;
              border-radius: 3px 0 0 3px;
            }
            
            /* On hover, add a black background color with a little bit see-through */
            .prev:hover, .next:hover {
              background-color: rgba(0,0,0,0.8);
            }
            
            /* Caption text */
            .text {
              color: #f2f2f2;
              font-size: 15px;
              padding: 8px 12px;
              position: absolute;
              bottom: 8px;
              width: 100%;
              text-align: center;
            }
            
            /* Number text (1/3 etc) */
            .numbertext {
              color: #f2f2f2;
              font-size: 12px;
              padding: 8px 12px;
              position: absolute;
              top: 0;
            }
            
            /* The dots/bullets/indicators */
            .dot {
              cursor: pointer;
              height: 15px;
              width: 15px;
              margin: 0 2px;
              background-color: #bbb;
              border-radius: 50%;
              display: inline-block;
              transition: background-color 0.6s ease;
            }
            
            .active, .dot:hover {
              background-color: #717171;
            }
            
            /* Fading animation */
            .fade {
              animation-name: fade;
              animation-duration: 1.5s;
            }
            
            @keyframes fade {
              from {opacity: .4} 
              to {opacity: 1}
            }
            
            /* On smaller screens, decrease text size */
            @media only screen and (max-width: 300px) {
              .prev, .next,.text {font-size: 11px}
            }

            body {
    font-family: Arial, sans-serif;
    margin: 0;
    padding: 0;
    line-height: 1.6;
}



nav ul {
    list-style: none;
    padding: 0;
    text-align: center;
}

nav ul li {
    display: inline;
    margin: 0 15px;
}

nav ul li a {
    color: white;
    text-decoration: none;
    font-weight: bold;
}

main {
    padding: 20px;
    text-align: center;
}

h1, h2 {
    color: #333;
}

p {
    color: #666;
}

img {
    max-width: 100%;
    height: auto;
    margin-top: 20px;
}

.texto img {
    display: block; 
    max-width: 70%; 
    height: auto;
    margin: 50px auto 0; 
    border-radius: 8px; 
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); 
}


.input-group {
    margin-bottom: 15px;
    text-align: left;
}

label {
    display: block;
    margin-bottom: 5px;
}

input {
    width: 100%;
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 4px;
}

button {
    width: 100%;
    padding: 10px;
    background-color: #5cb85c;
    border: none;
    
}


.container {
    max-width: 1200px;
    margin: 20px auto;
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
    gap: 20px;
    padding: 10px;
}
.card {
    background: white;
    border-radius: 8px;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    overflow: hidden;
    transition: transform 0.2s;
}
.card img {
    width: 100%;
    height: auto;
}
.card:hover {
    transform: translateY(-5px);
}
.card-content {
    padding: 15px;
}
.card-content h3 {
    margin: 0 0 10px;
    color: #00b3e6;
}
.card-content p {
    color: #555;
    font-size: 14px;
}

footer{
    text-align: center;
}
.texto {
    display: flex;
    justify-content: center;
    align-items: center;
    margin: 20px 0;
}
            </style>
            
            
            <div class="slideshow-container">
            
            <div class="mySlides fade">
              <div class="numbertext">1 / 3</div>
              <img src="https://www.provet.cloud/hubfs/Veterinarian_hugs_dog.jpg" style="width:100%">
              <div class="text"></div>
            </div>
            
            <div class="mySlides fade">
              <div class="numbertext">2 / 3</div>
              <img src="https://www.promedco.com/images/NOTICIAS_2020/reducir-estres-de-mascotas-1.jpg" style="width:100%">
              <div class="text"></div>
            </div>
            
            <div class="mySlides fade">
              <div class="numbertext">3 / 3</div>
              <img src="https://blog.uvm.mx/hs-fs/hubfs/Blog_Contenido/UG/estudiar_para_veterinario_en_uvm.jpg?width=800&name=estudiar_para_veterinario_en_uvm.jpg" style="width:100%">
              <div class="text"></div>
            </div>
            
            <a class="prev" onclick="plusSlides(-1)">❮</a>
            <a class="next" onclick="plusSlides(1)">❯</a>
            
            </div>
            <br>
            
            <div style="text-align:center">
              <span class="dot" onclick="currentSlide(1)"></span> 
              <span class="dot" onclick="currentSlide(2)"></span> 
              <span class="dot" onclick="currentSlide(3)"></span> 
            </div>
            
<script>
    let slideIndex = 1;
    showSlides(slideIndex);
    
    function plusSlides(n) {
      showSlides(slideIndex += n);
    }
    
    function currentSlide(n) {
      showSlides(slideIndex = n);
    }
    
    function showSlides(n) {
      let i;
      let slides = document.getElementsByClassName("mySlides");
      let dots = document.getElementsByClassName("dot");
      if (n > slides.length) {slideIndex = 1}    
      if (n < 1) {slideIndex = slides.length}
      for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";  
      }
      for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
      }
      slides[slideIndex-1].style.display = "block";  
      dots[slideIndex-1].className += " active";
    }
    </script>
</center>
 
        <div class="container">
            <div class="card">
                <img src="https://s1.significados.com/foto/gato-rasgos-fi-sicos-1.jpg?class=article" alt="Gato">
                <div class="card-content">
                    <h3>Epilepsia en gatos: Síntomas, causas y tratamiento</h3>
                    <p>Enfermedades / Glosario de enfermedades animales de compañía</p>
                </div>
            </div>
            <div class="card">
                <img src="https://veterinariasedavi.com/new/wp-content/uploads/2020/11/planes-salud-perro-clinica-veterinaria-sedavi.jpg" alt="Perro en consulta">
                <div class="card-content">
                    <h3>Fenobarbital en el tratamiento de las convulsiones caninas</h3>
                    <p>Salud</p>
                </div>
            </div>
            <div class="card">
                <img src="https://www.animalhome.com.mx/wp-content/uploads/2019/11/perro-viejo.png" alt="Perro anciano">
                <div class="card-content">
                    <h3>Cómo hacer feliz a un perro anciano: Guía para su bienestar físico y emocional</h3>
                    <p>Cuidados especiales y Bienestar</p>
                </div>
            </div>
            <div class="card">
                <img src="https://via.placeholder.com/300x200" alt="Perro anciano">
                <div class="card-content">
                    <h3>Cómo hacer feliz a un perro anciano: Guía para su bienestar físico y emocional</h3>
                    <p>Cuidados especiales y Bienestar</p>
                </div>
            </div>
            <div class="card">
                <img src="https://via.placeholder.com/300x200" alt="Perro anciano">
                <div class="card-content">
                    <h3>Cómo hacer feliz a un perro anciano: Guía para su bienestar físico y emocional</h3>
                    <p>Cuidados especiales y Bienestar</p>
                </div>
            </div>
            <div class="card">
                <img src="https://via.placeholder.com/300x200" alt="Perro anciano">
                <div class="card-content">
                    <h3>Cómo hacer feliz a un perro anciano: Guía para su bienestar físico y emocional</h3>
                    <p>Cuidados especiales y Bienestar</p>
                </div>
            </div>
        </div>
    

    <footer>
        <p>&copy; 2023 Veterinaria. Todos los derechos reservados.</p>
    </footer>
    <script>
        const slider = document.querySelector('.slider-box ul');
        const slides = document.querySelectorAll('.slider-box li');
        const prev = document.querySelector('.prev');
        const next = document.querySelector('.next');

        let index = 0;
        const totalSlides = slides.length;

        function updateSlider() {
            // Ajustar el ancho para que siempre esté centrado
            slider.style.transform = `translateX(-${index * 100}%)`;
        }

        function goToNext() {
            index = (index + 1) % totalSlides; // Ciclo infinito
            updateSlider();
        }

        function goToPrev() {
            index = (index - 1 + totalSlides) % totalSlides; // Ciclo inverso
            updateSlider();
        }

        next.addEventListener('click', goToNext);
        prev.addEventListener('click', goToPrev);

        // Desplazamiento automático cada 5 segundos
        setInterval(goToNext, 5000);

    </script>
     <footer>
     <div class="col">
        <h3></h3><br>
            <p></p>
   
    </div>
   
    <div class="footer-container">
        <div class="row">
            <div class="col">
                <h3>Redes Sociales</h3><br>
                    <p><img src="../css/images/facebook.png" alt=" "> Facebook: PetVida_SV</p>
                    <p><img src="https://cdn-icons-png.flaticon.com/256/1409/1409946.png" alt=""> Instagram: PetVida_SV</p>
                    <p><img src="../css/images/twitter.png" alt=""> X (Twitter): PetVida_SV</p>
            </div>
            <div class="col">
                <h3>Contáctenos</h3><br>
                    <p>Calle Arce 17 avenida Norte 
                    <br>San Salvador, El Salvador, CA. </p>
                    <p>Correo: PetVida@gmail.com</p>
                    <p>Tel. +503 2830-3243</p>
            </div>

             <div class="col">
                 <h3>sic-parvis-magna</h3><br>
                     <p>"la grandeza nace de pequeños comienzos".</p>
                    
             </div>

            
        </div>
    </div>

</footer>
</asp:Content>

