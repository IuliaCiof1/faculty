<?php
    $mysqli = mysqli_connect("localhost","root","root") or die("Eroare. Nu se poate conecta la server");
    mysqli_select_db($mysqli, "Evidenta");

    if(isset($_POST["btnMedie"])){
        $medie = $_POST["txtMedie"];
        $result = mysqli_query($mysqli, "select * from studenti where media>='".$medie."'")or die ("Query3 esuat");
        
        echo "<h4>Studenti cu media mai mare de: ".$medie."</h4>";
        echo "<table><tr><th>ID</th><th>Nume</th><th>Prenume</th><th>Grupa</th><th>Nota1</th><th>Nota2</th><th>Medie</th></tr>";
        while($row=mysqli_fetch_row($result)){
            echo "<tr>";
            foreach($row as $value){
                echo "<td>".$value."</td>";
            }
            echo "</tr>";
        }
        echo "</table><br><br>";
        echo "<a href=http://localhost/Evidenta/medieScript.php>Inapoi</a>";
    }

    if(isset($_POST["btnSterge"])){
            $medie = $_POST["txtMedie"];
            mysqli_query($mysqli, "delete from studenti where media<'".$medie."'") or die ("Query 3 esuat");
            $result = mysqli_query($mysqli, "select * from studenti");
            echo "<table><tr><th>ID</th><th>Nume</th><th>Prenume</th><th>Grupa</th><th>Nota1</th><th>Nota2</th><th>Medie</th></tr>";
            while($row=mysqli_fetch_row($result)){
                echo "<tr>";
                foreach($row as $value){
                    echo "<td>".$value."</td>";
                }
                echo "</tr>";
            }
            echo "</table><br><br>";
            echo "<a href=http://localhost/Evidenta/medieScript.php>Inapoi</a>";
    }

        mysqli_close($mysqli);
?>