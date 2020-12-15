using UnityEngine;


namespace NonOPTorches
{
    public class Implementation
    {
        private const string NAME = "random-Matchboxes";
        public static double HPnotround;
        public static void OnLoad()
        {
            Log("Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);


            HPnotround = 0f;
        }

        
       
      

      


   


        internal static void Log(string message)
        {
            Debug.Log( message);
        }


    }
   
}