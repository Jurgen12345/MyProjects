package com.example.final_project_gamestart

import android.content.Intent
import android.graphics.Color
import android.os.Bundle
import android.text.InputType
import android.util.Log
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        val editUsernameText = findViewById<EditText>(R.id.UserName)
        val editPasswordText = findViewById<EditText>(R.id.Password)
        val loginButton = findViewById<Button>(R.id.LogInButton)
        val registerButton = findViewById<Button>(R.id.RegisterButton)
        var usercounter = 0
        var passcounter = 0
        UserManager.currentUserCount = UserManager.users.size



        loginButton.setOnClickListener{

            if(editUsernameText.text.toString().equals("")){
                editUsernameText.setHint("** Username is required in order to continue")
                editUsernameText.setHintTextColor(Color.RED)
            }
            if(editPasswordText.text.toString().equals("")){
                editPasswordText.setHint("** Password is required in order to continue")
                editPasswordText.setHintTextColor(Color.RED)
            }


            UserManager.authenticateUser(this,editUsernameText.text.toString(),editPasswordText.text.toString(), "user.jpg"){
                user ->
                Log.v("User",user.toString())

                if(user !=null){
                    UserManager.currentUser = user
                    val intent = Intent(this,HomeActivity::class.java)
                    Toast.makeText(this,"Authentication succeeded! Welcome Back! ${editUsernameText.text.toString()}",Toast.LENGTH_LONG).show()
                    startActivity(intent)

                }else{
                    Toast.makeText(this,"Authentication failed! User Not Found",Toast.LENGTH_LONG).show()
                }
            }
        }


        registerButton.setOnClickListener{


            if(editUsernameText.text.toString().equals("") || editPasswordText.text.toString().equals("")){
                editUsernameText.setHint("** Username required in order to create account")
                editUsernameText.setHintTextColor(Color.RED)
                editPasswordText.setHint("** Password required in order to create account")
                editPasswordText.setHintTextColor(Color.RED)
            }else if(!editUsernameText.text.toString().equals("")){
                UserManager.createUser(this,editUsernameText.text.toString(), editPasswordText.text.toString(), "user.jpg"){
                    user->
                    if(user != null) {
                        UserManager.currentUser = user
                        val intent = Intent(this, HomeActivity::class.java)
                        Toast.makeText(this, "User Created Successfully! Welcome ${editUsernameText.text.toString()}", Toast.LENGTH_LONG).show()
                        startActivity(intent)
                    }else{
                        Toast.makeText(this,"Authentication failed! User Not Found",Toast.LENGTH_LONG).show()
                    }
                }
            }



        }


    }
}