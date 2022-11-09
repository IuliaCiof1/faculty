<!DOCTYPE html>
<html>
    <head>
    <?php
            $mysqli = mysqli_connect("localhost", "root", "root") or die ("Nu se poate conecta la serverul MySQL");

            mysqli_select_db($mysqli, "Evidenta") or die ("Nu se poate conecta la baza de date Evidenta");
            
            //calculeaza media intre coloanele nota1 si nota2 si pune rezultatul in coloana "media"
            mysqli_query($mysqli, "update studenti set media = (nota1 + nota2)/2") or die ("Query1 esuat");
        
            //echo "<table><tr><th>ID</th><th>Nume</th><th>Prenume</th><th>Grupa</th><th>Nota1</th><th>Nota2</th><th>Medie</th></tr>";
            echo "<table><tr>";
            $result = mysqli_query($mysqli,"select * from studenti") or die ("Query2 esuat");

            $coln = mysqli_num_fields($result);
            for ($i=0; $i<$coln; $i++){
                //numele câmpurilor ca şi cap de tabel
                $var=mysqli_fetch_field_direct($result,$i); //$var=mysqli_field_name($query,$i);
                echo "<th> $var->name </th>";                //echo "<th> $var</th>";
            }

            echo "</tr>";


            while($row=mysqli_fetch_row($result)){
                echo "<tr>";
                foreach($row as $value){
                    echo "<td>".$value."</td>";
                }
                echo "</tr>";
            }
            echo "</table><br>";

            mysqli_close($mysqli);
        ?>

    </head>

    <body>

        <form action="http://localhost/Evidenta/Script.php", method="POST">
            <label for="txtMedie">Medie: </label>
            <input type="text" id="txtMedie", name="txtMedie"/>
            <br><br><br>
            <button type="submit", id="btnMedie", name="btnMedie">Afiseaza mediile mai mari</button>
            <button type="submit", id="btnSterge", name="btnSterge">Sterge mediile mai mici</button>
        </form>
        
    </body>
</html>