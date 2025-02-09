package com.example.final_project_gamestart

import android.content.Context
import android.content.Intent
import android.text.Layout
import android.util.Log
import android.view.LayoutInflater
import android.view.ViewGroup
import android.widget.Button
import android.widget.ImageView
import android.widget.TextView
import android.widget.Toast
import androidx.core.view.isVisible
import androidx.recyclerview.widget.RecyclerView

class GameAdapter(private val context:Context, private val games:ArrayList<Game>)
    : RecyclerView.Adapter<RecyclerView.ViewHolder>(){
    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): RecyclerView.ViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.game_list_layout,parent,false)
        return object: RecyclerView.ViewHolder(view){}
    }

    override fun getItemCount(): Int {
        return games.size
    }

    override fun onBindViewHolder(holder: RecyclerView.ViewHolder, position: Int) {
        val game = games[position]
        val image =holder.itemView.findViewById<ImageView>(R.id.GameImage)
        val imgdrawable =when(game.image){
            "dark_souls.jpg" ->R.drawable.dark_souls
            "dark_souls_3.jpg" -> R.drawable.dark_souls_3
            "elden_ring.jpg" -> R.drawable.elden_ring
            "skyrim.jpg" -> R.drawable.skyrim
            "league_of_legends.jpg" -> R.drawable.league_of_legends
            "world_of_warcraft.jpg" -> R.drawable.world_of_warcraft
            else -> R.drawable.ic_launcher_background
        }
        image.setImageResource(imgdrawable)
        holder.itemView.findViewById<TextView>(R.id.GameTitle).text = game.title
        holder.itemView.findViewById<TextView>(R.id.GameGenre).text = game.Genre
        holder.itemView.findViewById<TextView>(R.id.GameDescription).text = game.description


        UserManager.getLibraryData(context,UserManager.currentUser.id){

            Log.v("library_games",UserManager.libraryGamesId.toString())

            if(!UserManager.isInLibrary(game.id)){
                holder.itemView.findViewById<Button>(R.id.LibraryButton).text = "+"
            }else{
                holder.itemView.findViewById<Button>(R.id.LibraryButton).text = "-"
            }
        }



        holder.itemView.setOnClickListener{
            val intent = Intent(context,GameInfoActivity::class.java)
            intent.putExtra("title",game.title)
            intent.putExtra("genre",game.Genre)
            intent.putExtra("description",game.description)
            intent.putExtra("imageId",game.image)
            context.startActivity(intent)
        }



        holder.itemView.findViewById<Button>(R.id.LibraryButton).setOnClickListener{
            if(holder.itemView.findViewById<Button>(R.id.LibraryButton).text == "+") {
                UserManager.addToLibrary(context, UserManager.currentUser.id, game) {
                    holder.itemView.findViewById<Button>(R.id.LibraryButton).text = "-"
                    Toast.makeText(
                        context,
                        game.title + " has been added to your library",
                        Toast.LENGTH_LONG
                    ).show()

                }
            }else if(holder.itemView.findViewById<Button>(R.id.LibraryButton).text == "-"){

                UserManager.removeFromLibrary(context,UserManager.currentUser.id){
                    UserManager.currentUser.libraryGames.remove(game)
                    holder.itemView.findViewById<Button>(R.id.LibraryButton).text = "+"
                    Toast.makeText(context,game.title + " has been removed from your library", Toast.LENGTH_LONG).show()
                    notifyDataSetChanged()
                }

            }


        }

        holder.itemView.findViewById<Button>(R.id.WishlistButton).setOnClickListener{
            if(holder.itemView.findViewById<Button>(R.id.WishlistButton).text == "Add to wishlist"){
                UserManager.addToWishlist(context,UserManager.currentUser.id, game){
                    holder.itemView.findViewById<Button>(R.id.WishlistButton).text = "Remove from wishlist"
                    Toast.makeText(context, game.title + " has been added to your wishlist", Toast.LENGTH_LONG).show()
                }
            }else if(holder.itemView.findViewById<Button>(R.id.WishlistButton).text == "Remove from wishlist"){
                UserManager.removeFromWishlist(context,UserManager.currentUser.id){
                   UserManager.currentUser.wishlistedGames.remove(game)
                   holder.itemView.findViewById<Button>(R.id.WishlistButton).text = "Add to wishlist"
                    Toast.makeText(context, game.title + " has been removed from your wishlist", Toast.LENGTH_LONG).show()
                    notifyDataSetChanged()
                }
            }
        }



    }


}