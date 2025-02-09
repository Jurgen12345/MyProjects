package com.example.final_project_gamestart

import android.Manifest
import android.app.Activity
import android.content.Context
import android.content.Intent
import android.content.pm.PackageManager
import android.graphics.Bitmap
import android.net.Uri
import android.os.Build
import android.os.Bundle
import android.provider.MediaStore
import android.text.Editable
import android.util.Log
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.EditText
import android.widget.ImageView
import android.widget.SearchView
import android.widget.TextView
import android.widget.Toast
import androidx.activity.result.ActivityResultCallback
import androidx.activity.result.ActivityResultLauncher
import androidx.activity.result.contract.ActivityResultContract
import androidx.activity.result.contract.ActivityResultContracts
import androidx.core.app.ActivityCompat
import androidx.core.content.ContextCompat
import java.io.IOError
import java.io.IOException


class ProfileFragment : Fragment() {

    lateinit var activityContext:Context
    lateinit var profilePic:ImageView






    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)


    }


    override fun onAttach(context: Context) {
        super.onAttach(context)
        activityContext = context
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {

        return inflater.inflate(R.layout.fragment_profile, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        val changeUsername = view.findViewById<Button>(R.id.ProfileChangeUsernameButton)
        val changePassword = view.findViewById<Button>(R.id.ProfileChangePassword)
        profilePic = view.findViewById<ImageView>(R.id.ProfilePicture)
        val username = view.findViewById<TextView>(R.id.ProfileUsername)
        val changeImage = view.findViewById<Button>(R.id.ProfileChangeImage)
        val profileusernameedit = view.findViewById<EditText>(R.id.ProfileUsernameEditText)
        val profilepasswordedit =view.findViewById<EditText>(R.id.ProfilePasswordEditText)
        profilePic.setImageURI(UserManager.selectedImage)


        val cutJPG = UserManager.currentUser.imageId.substringBefore(".")
        Log.v("ProfileFragment", "Image ID: ${cutJPG}")

        val resourceId = resources.getIdentifier(cutJPG, "drawable", activityContext.packageName)

        Log.v("ProfileFragment", "Resource ID: $resourceId")

        if(resourceId != 0){
            profilePic.setImageResource(resourceId)
        }else{
            profilePic.setImageResource(R.drawable.ic_launcher_background)
        }

        username.text = UserManager.currentUser.username
        profileusernameedit.text = Editable.Factory.getInstance().newEditable(UserManager.currentUser.username)
        profilepasswordedit.text = Editable.Factory.getInstance().newEditable(UserManager.currentUser.password)


        changeUsername.setOnClickListener{
             val newusername = profileusernameedit.text.toString()
            if(!newusername.equals("")){
                UserManager.changeUsername(activityContext, UserManager.currentUser.id, newusername){
                    Toast.makeText(activityContext, "Username changed successfully", Toast.LENGTH_LONG).show()
                }
            }

        }

        changePassword.setOnClickListener{
            val newpassword = profilepasswordedit.text.toString()
            if(!newpassword.equals("")){
                UserManager.changePassword(activityContext,UserManager.currentUser.id, newpassword){
                    Toast.makeText(activityContext, "Password changed successfully", Toast.LENGTH_LONG).show()
                }
            }
        }


       val galleryImage  = registerForActivityResult(ActivityResultContracts.GetContent()){
           uri ->
                UserManager.selectedImage = uri
                profilePic.setImageURI(uri)

       }


        changeImage.setOnClickListener{
            galleryImage.launch("image/*")
            Log.v("imageidname",UserManager.currentUser.imageId.toString())

        }



    }









}

