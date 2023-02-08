<div align = center>

![Comment cloner](doc/Images/Banner.png)

</div>


**Thème du projet** : Réalisation d'une API et d'un ORM(Entity Framework) qui seront reliés à une base de données dans le thème de League of Legends <img src="https://logo-marque.com/wp-content/uploads/2020/11/League-of-Legends-Embleme.png" width="40" >
</br>

<img src="doc/Images/Title-Répartition.png" width="400">

La racine de notre gitlab est composée de deux dossiers essentiels au projet:

[**src**](src) : **Toute la partie codage de l'application**

[**doc**](doc) : **Documentation de l'application**

👉 [**Solution de l'application**](src/EntityFramework_LoL/Sources/LeagueOfLegends.sln)


<img src="doc/Images/Title-Fonctionnement.png" width="460" >

- ### Comment récupérer le projet ? 

Tout d'abord si ce n'est pas fait cloner le dépôt de la branche **master/main**, pour cela copier le lien URL du dépôt git :

<div align = center>

![Comment cloner](doc/Images/HowToClone.png)

</div>

Vous pouvez le cloner via un terminal dans le répertoire que vous souhaitez en tapant la commande : **git clone https://codefirst.iut.uca.fr/git/emre.kartal/LolProject.git** ou utiliser Visual Studio et cloner en entrant le lien :

<div align = center>

![Page Visual studio](doc/Images/PageVS.png)

</div>

:information_source: *Si vous ne disposez pas de Visual Studio, allé sur le site [Microsoft Visual Studio](https://visualstudio.microsoft.com/fr/downloads/) pour pouvoir le télécharger !!!*


- ### Comment lancer Le projet Entity Framework ? 

Afin de générer les migrations et les tables.
<br>
Vous devez avoir installé correctement EntityFrameworkCore, pour cela il existe la commande : **dotnet tool install --global dotnet-ef** qui peut être lancé à partir d'un terminal, si il est déjà installer mais n'a pas la bonne version : **dotnet tool update --global dotnet-ef** (oui y que le *install* qui change vous êtes perspicace)!

Aussi assurer vous d'avoir installé sur Visual Studio au préalable les package Nuget suivants : 

<div align = center>

![package nuget](doc/Images/Package_Nuget.png)

</div>

Ensuite sur le terminal PowerShell ou Visual Studio, lancer la migration via la commande : **dotnet ef migrations add monNomDeMigration** (n'oublier pas de vous situer dans le dossier "/MyFlib" lorsque vous l'exécuter)!

- ### Comment voir la base de données ?

C'est bien beau toutes ces étapes mais s’il n'y a pas de résultat à quoi cela sert !

Tout d'abord veuillez regarder dans l'onglet extension, si l'outil **SQLite and SQL Server Compact Toolbax** est bien installé.

Puis, afin de visualiser la migration dans la base de données, cliquer dans l'onglet **Outils**->**SQLLite/ SQL Server compact Toolbox** :

<div align = center>

![start BD](doc/Images/Start_BD.png)

</div>

Et enfin cliquer sur l'icône ci-dessous pour faire la connexion à la solution courent :

<div align = center>

![Connection BD](doc/Images/Connection_BD.png)

</div>

Vous pouvez dorénavant voir toutes les tables qui y sont enregistrées ! Si vous souhaitez ajouter des modifications à la base de données et les visualiser, 
réaliser à nouveau la migration (ou *updater* celui actuel), puis supprimer toutes les tables et lancer la commande : **dotnet ef database update** et enfin rafraichissez la BD !

:information_source: *Notez qu'il est également possible grâce à SQLLite d'ajouter, modifier ou supprimer des données dans les tables.*

<img src="doc/Images/Title-Environnement.png" width="400" >

Mon environnement de travail se base sur un outil et un langage en particulier :👇

<div align = center>

---

&nbsp; ![Docnet](https://img.shields.io/badge/Docnet-000?style=for-the-badge&logo=Docnet&logoColor=white&color=white)
&nbsp; ![C#](https://img.shields.io/badge/Csharp-000?style=for-the-badge&logo=csharp&logoColor=white&color=blue)

---

</div>

<img src="doc/Images/Title-Technicien.png" width="400" >

⚙️ Emre KARTAL
<br>

<div align = center>
© PM2
</div>