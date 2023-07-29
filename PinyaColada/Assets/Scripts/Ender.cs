using System;
using UnityEngine;
/*
El propósito de este script es controlar la pantalla del fin del juego. Verificar que si se cumplen o no los criterios
para obtener el final bueno de cada ruta. - Bea
*/

public class Ender : MonoBehaviour
{
    // TODO: modificar esto - Bea
    static readonly String MomGoodEnding1 = "012311303";
    static readonly String MomGoodEnding2 = "012213303";
    static readonly String DadGoodEnding = "32103120312"; 
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnEnable(){
        //debería ser esta la función?? //onWake?? no sé mucho de unity - Bea
        //pillar datos de la partida y llamar a las funciones así:
        if(IsGoodEnding("MOM","012311303"))  {  
            playGoodEnding("MOM");
        }
        else{
            playBadEnding();
        }
        
    }

    private void playBadEnding(){
        //TODO ilustración final por defecto + musicote
    }

    /*
     * Esta función muestra la pantalla de final bueno dependiendo de la ruta (persona a la que llamas) es un string por
     * poner algo, TODO: cambiar el tipo. - Bea
     */
    void playGoodEnding(String contact){
        switch (contact){
            case "MOM":
                // Ilustración y diálogo con mamá
                break;
            case "DAD":
                // Ilustación y diálogo con papá
                break;
            case "ALFREDO, TONY?? WHAT IS THEIR NAMEEE??":
                // pues eso
                break;
            default:
                break;
        }
    }
    bool IsGoodEnding(String contact, String convoTracker){
        bool ending = false;
        // TODO: añadir parámetros de entrada, "persona con la que hablas" string??, "lista de elecciones de diálogo" lista??
        switch (contact){
            case "MOM":
                return convoTracker.Equals(MomGoodEnding1) || convoTracker.Equals(MomGoodEnding2);
            case "DAD":
                return false; //TODO: implementar
            default:
                return false;
        }
    }
        
}
