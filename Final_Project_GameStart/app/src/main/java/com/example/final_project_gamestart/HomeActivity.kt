package com.example.final_project_gamestart

import android.content.Intent
import android.media.Image
import android.os.Bundle
import android.util.Log
import android.view.Gravity
import android.view.LayoutInflater
import android.view.MenuItem
import android.widget.ImageButton
import android.widget.ImageView
import android.widget.SearchView
import android.widget.TextView
import androidx.appcompat.widget.Toolbar
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.ActionBarDrawerToggle
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.GravityCompat
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.drawerlayout.widget.DrawerLayout
import com.google.android.material.navigation.NavigationView


class HomeActivity : AppCompatActivity(), NavigationView.OnNavigationItemSelectedListener {
    lateinit var drawerLayout: DrawerLayout
    lateinit var profileName: TextView


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_home)




        drawerLayout = findViewById(R.id.home)
        val toolbar = findViewById<Toolbar>(R.id.toolbarContainer)
        setSupportActionBar(toolbar)
        val naview = findViewById<NavigationView>(R.id.navigationView)
        naview.setNavigationItemSelectedListener(this)


        val inflater =  layoutInflater
        val headerview = inflater.inflate(R.layout.side_bar_header,naview,false)
        naview.addHeaderView(headerview)
        val profileName = headerview.findViewById<TextView>(R.id.ProfileName)
        val profileImage = headerview.findViewById<ImageView>(R.id.SideBarImage)
        profileImage.setImageURI(UserManager.selectedImage)
        profileName.text = UserManager.currentUser.username.toString()




        val toggle = ActionBarDrawerToggle(this,drawerLayout,toolbar,R.string.open_nav,R.string.close_nav)
        drawerLayout.addDrawerListener(toggle)
        toggle.syncState()

        if(savedInstanceState == null){
            supportFragmentManager.beginTransaction().replace(R.id.fragment_container, HomeFragment()).commit()
            naview.setCheckedItem(R.id.nav_home)
        }





    }

    override fun onNavigationItemSelected(p0: MenuItem): Boolean {
        when(p0.itemId){
            R.id.nav_home -> supportFragmentManager.beginTransaction().replace(R.id.fragment_container,HomeFragment()).commit()

            R.id.nav_profile -> supportFragmentManager.beginTransaction().replace(R.id.fragment_container,ProfileFragment()).commit()

            R.id.nav_library -> supportFragmentManager.beginTransaction().replace(R.id.fragment_container,LibraryFragment()).commit()

            R.id.nav_wishlist -> supportFragmentManager.beginTransaction().replace(R.id.fragment_container,WishlistFragment()).commit()

            R.id.nav_logOut -> startActivity(Intent(this,MainActivity::class.java))



        }
        drawerLayout.closeDrawer(GravityCompat.START)
        return true
    }

    override fun onBackPressed() {
        super.onBackPressed()
        if(drawerLayout.isDrawerOpen(GravityCompat.START)){
            drawerLayout.closeDrawer(GravityCompat.START)


        }else{
            onBackPressedDispatcher.onBackPressed()
        }
    }


}