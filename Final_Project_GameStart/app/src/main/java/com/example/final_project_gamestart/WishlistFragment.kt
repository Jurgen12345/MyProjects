package com.example.final_project_gamestart

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ListView
import androidx.cardview.widget.CardView


class WishlistFragment : Fragment() {

    lateinit var lv: ListView
    lateinit var wishlistadapter: WishlistGamesAdapter

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_wishlist, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        UserManager.getWishlistData(requireContext(),UserManager.currentUser.id){
            lv = view.findViewById(R.id.WishlistListView)
            wishlistadapter = WishlistGamesAdapter(requireContext(),UserManager.currentUser.wishlistedGames)
            lv.adapter = wishlistadapter
        }
    }



}