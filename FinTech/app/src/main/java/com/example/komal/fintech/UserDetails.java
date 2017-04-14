package com.example.komal.fintech;

/**
 * Created by Komal on 14/04/2017.
 */
public class UserDetails {
    public  static String username;
    public  static  String password;
    public static boolean is_loged_in;
    public UserDetails(String susername,String spassword)
    {
        username = new String(susername);
        password=new String(spassword);
        is_loged_in=true;
    }

     public static String getUsername() {
        return username;
    }
    public static String getPassword() {
        return username;
    }
    public static boolean isLogedIn() {
        return is_loged_in;
    }

    public static void setUsername(String susername) {
         username = susername;
        return;
    }
    public static void setPassword(String spassword) {
        username=spassword;
        return;
    }
    public static void setIsLogedIn() {
        is_loged_in=true;
        return;
    }

}
