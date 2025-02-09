package com.example.final_project_gamestart

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.BaseAdapter
import android.widget.Button
import android.widget.ImageView
import android.widget.TextView
import android.widget.Toast
import androidx.cardview.widget.CardView
import androidx.recyclerview.widget.RecyclerView.ViewHolder

class WishlistGamesAdapter(private val context:Context, private val games:ArrayList<Game> ) :BaseAdapter(){

    private class ViewHolder(row:View?){
        var gameImage: ImageView = row?.findViewById(R.id.WishlistImage) as ImageView
        var gameTitle: TextView = row?.findViewById(R.id.WishlistGameTitle) as TextView
        var gameGenre: TextView = row?.findViewById(R.id.WishlistGameGenre) as TextView
        var gameDescription: TextView = row?.findViewById(R.id.WishlistGameDescription) as TextView
        var wishlistButton: Button = row?.findViewById(R.id.WishlistButtonForGames) as Button
    }


    override fun getCount(): Int {
        return games.size
    }

    override fun getItem(position: Int): Any {
        return games.get(position)
    }

    override fun getItemId(position: Int): Long {
        return position.toLong()
    }

    override fun getView(position: Int, convertView: View?, parent: ViewGroup?): View {
        val view:View
        val viewHolder:ViewHolder
        if(convertView == null){
            val inflater = context.getSystemService(Context.LAYOUT_INFLATER_SERVICE) as LayoutInflater
            view = inflater.inflate(R.layout.wishlist_layout,parent,false)
            viewHolder = ViewHolder(view)
            view.tag = viewHolder
        }else{
            view = convertView
            viewHolder = view.tag as ViewHolder
        }
        val game = games[position]
        viewHolder.gameTitle.text = game.title
        viewHolder.gameGenre.text = game.Genre
        viewHolder.gameDescription.text = game.description
        val imgDrawable = when (game.image) {
            "dark_souls.jpg" -> R.drawable.dark_souls
            "dark_souls_3.jpg" -> R.drawable.dark_souls_3
            "elden_ring.jpg" -> R.drawable.elden_ring
            "skyrim.jpg" -> R.drawable.skyrim
            "league_of_legends.jpg" -> R.drawable.league_of_legends
            "world_of_warcraft.jpg" -> R.drawable.world_of_warcraft
            else -> R.drawable.ic_launcher_background
        }
        viewHolder.gameImage.setImageResource(imgDrawable)

        viewHolder.wishlistButton.setOnClickListener{
            UserManager.removeFromWishlist(context, UserManager.currentUser.id){
                Toast.makeText(context, game.title + " has been removed from your wishlist!",Toast.LENGTH_LONG).show()
            }
        }



        return view

    }

}