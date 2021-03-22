    const button = document.getElementById("nextButton");
    const buttonPreviousPage = document.getElementById("previousPageButton");
    const divPartOne = document.getElementById("partOne");
    const divPartTwo = document.getElementById("partTwo");

    divPartTwo.style.display = "none";

    const nextPartForm = () =>
    {
        divPartOne.style.display = "none";
        divPartTwo.style.display = "";
    }
    const previousPartForm = () => {
        divPartOne.style.display = "";
        divPartTwo.style.display = "none";

    }
    button.addEventListener("click", nextPartForm);
    buttonPreviousPage.addEventListener("click", previousPartForm);
