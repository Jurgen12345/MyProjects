package forms;
import data.*;
import data.COrderedStringArray;
import javax.swing.JFrame;


public class CFormEditor extends javax.swing.JFrame {

    COrderedStringArray words;
    CStringStack undoStack ;
    CStringQueue redoQueue ;
    COrderedIntegerArray counter;
    
    public CFormEditor() {
        initComponents();
        this.setTitle("Editor");
        this.setDefaultCloseOperation(JFrame.HIDE_ON_CLOSE); 
        this.words = new COrderedStringArray(32);
        this.undoStack = new CStringStack(32);
        this.redoQueue = new CStringQueue(32);
        this.counter = new COrderedIntegerArray(32);
        this.setTitle("Topic Editor");
    }

    private void Count()
        {
        
            String sWord = null;
            boolean bEndOf = false;
            String sCurrentGroup = null;
            boolean bIsFinishingGroup, bIsCreatingGroup;
            int nIndex = 0;
            int nCount = 0;
            while(!bEndOf)
            {
                 bEndOf = nIndex >= this.words.getItemCount();
                if(bEndOf)
                {
                sWord = null;
                bIsCreatingGroup = true;
                 }
                else
                {
                sWord = this.words.getItem(nIndex);
                bIsCreatingGroup = !sWord.equals(sCurrentGroup);
                }
                bIsFinishingGroup = bIsCreatingGroup;
            
                if(bIsFinishingGroup)
                {
                    System.out.println(sCurrentGroup + " " + nCount);
                }
                if(bIsCreatingGroup)
                {
                sCurrentGroup = sWord ;
                nCount = 1;
                }
                else
                {
                   nCount ++;
                   nIndex ++;
            
                String WordCountString = String.valueOf(nIndex);
                this.txtViewWordCount.setText(WordCountString);
            }
        }
    }
    
    
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jScrollPane1 = new javax.swing.JScrollPane();
        txtEditor = new javax.swing.JTextArea();
        btnSave = new javax.swing.JButton();
        btnFind = new javax.swing.JButton();
        txtViewUndo = new javax.swing.JTabbedPane();
        pnlWordsArray = new javax.swing.JPanel();
        txtViewWordArray = new javax.swing.JScrollPane();
        txtViewWords = new javax.swing.JTextArea();
        pnlCountsArray = new javax.swing.JPanel();
        txtViewCountArray = new javax.swing.JScrollPane();
        txtViewWordCount = new javax.swing.JTextArea();
        pnlUndoStack = new javax.swing.JPanel();
        txtViewUndoStack = new javax.swing.JScrollPane();
        txtUndoQueue = new javax.swing.JTextArea();
        pnlRedoQueue = new javax.swing.JPanel();
        txtViewRedoStack = new javax.swing.JScrollPane();
        txtViewRedo = new javax.swing.JTextArea();
        lblDataStructureViews = new javax.swing.JLabel();
        txtCountToFind = new javax.swing.JTextField();
        lblDataStructureViews1 = new javax.swing.JLabel();
        lblSearchResult = new javax.swing.JLabel();
        txtFoundIndex = new javax.swing.JTextField();
        btnUndo = new javax.swing.JButton();
        btnRedo = new javax.swing.JButton();
        btnSplit = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        txtEditor.setColumns(20);
        txtEditor.setRows(5);
        jScrollPane1.setViewportView(txtEditor);

        btnSave.setText("Save");
        btnSave.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnSaveActionPerformed(evt);
            }
        });

        btnFind.setText("Search");
        btnFind.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnFindActionPerformed(evt);
            }
        });

        txtViewWords.setColumns(20);
        txtViewWords.setRows(5);
        txtViewWordArray.setViewportView(txtViewWords);

        javax.swing.GroupLayout pnlWordsArrayLayout = new javax.swing.GroupLayout(pnlWordsArray);
        pnlWordsArray.setLayout(pnlWordsArrayLayout);
        pnlWordsArrayLayout.setHorizontalGroup(
            pnlWordsArrayLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(pnlWordsArrayLayout.createSequentialGroup()
                .addContainerGap()
                .addComponent(txtViewWordArray, javax.swing.GroupLayout.PREFERRED_SIZE, 586, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(19, Short.MAX_VALUE))
        );
        pnlWordsArrayLayout.setVerticalGroup(
            pnlWordsArrayLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(pnlWordsArrayLayout.createSequentialGroup()
                .addContainerGap()
                .addComponent(txtViewWordArray, javax.swing.GroupLayout.DEFAULT_SIZE, 259, Short.MAX_VALUE)
                .addContainerGap())
        );

        txtViewUndo.addTab("Words", pnlWordsArray);

        txtViewWordCount.setColumns(20);
        txtViewWordCount.setRows(5);
        txtViewCountArray.setViewportView(txtViewWordCount);

        javax.swing.GroupLayout pnlCountsArrayLayout = new javax.swing.GroupLayout(pnlCountsArray);
        pnlCountsArray.setLayout(pnlCountsArrayLayout);
        pnlCountsArrayLayout.setHorizontalGroup(
            pnlCountsArrayLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(pnlCountsArrayLayout.createSequentialGroup()
                .addContainerGap()
                .addComponent(txtViewCountArray, javax.swing.GroupLayout.PREFERRED_SIZE, 586, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(19, Short.MAX_VALUE))
        );
        pnlCountsArrayLayout.setVerticalGroup(
            pnlCountsArrayLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(pnlCountsArrayLayout.createSequentialGroup()
                .addContainerGap()
                .addComponent(txtViewCountArray, javax.swing.GroupLayout.DEFAULT_SIZE, 259, Short.MAX_VALUE)
                .addContainerGap())
        );

        txtViewUndo.addTab("Word Count", pnlCountsArray);

        txtUndoQueue.setColumns(20);
        txtUndoQueue.setRows(5);
        txtViewUndoStack.setViewportView(txtUndoQueue);

        javax.swing.GroupLayout pnlUndoStackLayout = new javax.swing.GroupLayout(pnlUndoStack);
        pnlUndoStack.setLayout(pnlUndoStackLayout);
        pnlUndoStackLayout.setHorizontalGroup(
            pnlUndoStackLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(pnlUndoStackLayout.createSequentialGroup()
                .addComponent(txtViewUndoStack, javax.swing.GroupLayout.PREFERRED_SIZE, 586, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(0, 29, Short.MAX_VALUE))
        );
        pnlUndoStackLayout.setVerticalGroup(
            pnlUndoStackLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addComponent(txtViewUndoStack, javax.swing.GroupLayout.DEFAULT_SIZE, 281, Short.MAX_VALUE)
        );

        txtViewUndo.addTab("Undo", pnlUndoStack);

        txtViewRedo.setColumns(20);
        txtViewRedo.setRows(5);
        txtViewRedoStack.setViewportView(txtViewRedo);

        javax.swing.GroupLayout pnlRedoQueueLayout = new javax.swing.GroupLayout(pnlRedoQueue);
        pnlRedoQueue.setLayout(pnlRedoQueueLayout);
        pnlRedoQueueLayout.setHorizontalGroup(
            pnlRedoQueueLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(pnlRedoQueueLayout.createSequentialGroup()
                .addContainerGap()
                .addComponent(txtViewRedoStack, javax.swing.GroupLayout.PREFERRED_SIZE, 586, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap(19, Short.MAX_VALUE))
        );
        pnlRedoQueueLayout.setVerticalGroup(
            pnlRedoQueueLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(pnlRedoQueueLayout.createSequentialGroup()
                .addContainerGap()
                .addComponent(txtViewRedoStack, javax.swing.GroupLayout.DEFAULT_SIZE, 259, Short.MAX_VALUE)
                .addContainerGap())
        );

        txtViewUndo.addTab("Redo", pnlRedoQueue);

        lblDataStructureViews.setText("Count of occurence:");

        lblDataStructureViews1.setFont(new java.awt.Font("Tahoma", 1, 12)); // NOI18N
        lblDataStructureViews1.setText("Data Structure Views");

        lblSearchResult.setText("Found at Index:");

        btnUndo.setText("Undo");
        btnUndo.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnUndoActionPerformed(evt);
            }
        });

        btnRedo.setText("Redo");
        btnRedo.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnRedoActionPerformed(evt);
            }
        });

        btnSplit.setText("Split");
        btnSplit.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                btnSplitActionPerformed(evt);
            }
        });

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(txtViewUndo)
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false)
                            .addComponent(btnSave, javax.swing.GroupLayout.DEFAULT_SIZE, 87, Short.MAX_VALUE)
                            .addComponent(btnUndo, javax.swing.GroupLayout.DEFAULT_SIZE, 87, Short.MAX_VALUE)
                            .addComponent(btnRedo, javax.swing.GroupLayout.DEFAULT_SIZE, 87, Short.MAX_VALUE)
                            .addComponent(btnSplit, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createSequentialGroup()
                                .addComponent(lblDataStructureViews)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                .addComponent(txtCountToFind)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                .addComponent(btnFind, javax.swing.GroupLayout.PREFERRED_SIZE, 87, javax.swing.GroupLayout.PREFERRED_SIZE)
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                                .addComponent(lblSearchResult)
                                .addGap(18, 18, 18)
                                .addComponent(txtFoundIndex, javax.swing.GroupLayout.PREFERRED_SIZE, 84, javax.swing.GroupLayout.PREFERRED_SIZE))
                            .addComponent(jScrollPane1)))
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(lblDataStructureViews1)
                        .addGap(0, 0, Short.MAX_VALUE)))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(btnSave, javax.swing.GroupLayout.PREFERRED_SIZE, 36, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(btnUndo, javax.swing.GroupLayout.PREFERRED_SIZE, 36, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(btnRedo, javax.swing.GroupLayout.PREFERRED_SIZE, 36, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addComponent(btnSplit, javax.swing.GroupLayout.PREFERRED_SIZE, 38, javax.swing.GroupLayout.PREFERRED_SIZE))
                    .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 201, javax.swing.GroupLayout.PREFERRED_SIZE))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(txtFoundIndex)
                    .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                        .addComponent(btnFind)
                        .addComponent(txtCountToFind)
                        .addComponent(lblDataStructureViews)
                        .addComponent(lblSearchResult)))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(lblDataStructureViews1)
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)
                .addComponent(txtViewUndo, javax.swing.GroupLayout.PREFERRED_SIZE, 309, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addContainerGap())
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void btnFindActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnFindActionPerformed
        String sWord = txtCountToFind.getText();
        txtFoundIndex.setText(Integer.toString(this.words.FastSearch(sWord)));
    }//GEN-LAST:event_btnFindActionPerformed

    private void btnSplitActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnSplitActionPerformed
        
        String sText = this.txtEditor.getText();
        String[] sParts = sText.split(" ");
        for(String sWord: sParts)
        {
            this.words.Add(sWord.toLowerCase());
        }
        this.Count();
        this.txtViewWords.setText(this.words.toString());
        this.txtUndoQueue.setText(this.undoStack.toString());
    }//GEN-LAST:event_btnSplitActionPerformed


    
    private void btnSaveActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnSaveActionPerformed
        // TODO add your handling code here:
        this.undoStack.Push(this.txtEditor.getText());
        this.txtUndoQueue.setText(this.undoStack.toString());
    }//GEN-LAST:event_btnSaveActionPerformed

    private void btnUndoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnUndoActionPerformed
        // TODO add your handling code here:
        this.redoQueue.Enqueue(this.txtEditor.getText());
        String sText = this.undoStack.Pop();
        this.txtEditor.setText(sText);
        this.txtUndoQueue.setText(this.undoStack.toString());
        this.txtViewRedo.setText(this.redoQueue.toString());
    }//GEN-LAST:event_btnUndoActionPerformed

    private void btnRedoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_btnRedoActionPerformed
        // TODO add your handling code here:
        String sText = this.redoQueue.Dequeue();
        this.txtEditor.setText(sText);
        
        this.txtViewRedo.setText(this.redoQueue.toString());
    }//GEN-LAST:event_btnRedoActionPerformed

    /**
     * @param args the command line arguments
     */
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(CFormEditor.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(CFormEditor.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(CFormEditor.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(CFormEditor.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>
        //</editor-fold>
        //</editor-fold>
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
                new CFormEditor().setVisible(true);
            }
        });
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton btnFind;
    private javax.swing.JButton btnRedo;
    private javax.swing.JButton btnSave;
    private javax.swing.JButton btnSplit;
    private javax.swing.JButton btnUndo;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JLabel lblDataStructureViews;
    private javax.swing.JLabel lblDataStructureViews1;
    private javax.swing.JLabel lblSearchResult;
    private javax.swing.JPanel pnlCountsArray;
    private javax.swing.JPanel pnlRedoQueue;
    private javax.swing.JPanel pnlUndoStack;
    private javax.swing.JPanel pnlWordsArray;
    private javax.swing.JTextField txtCountToFind;
    private javax.swing.JTextArea txtEditor;
    private javax.swing.JTextField txtFoundIndex;
    private javax.swing.JTextArea txtUndoQueue;
    private javax.swing.JScrollPane txtViewCountArray;
    private javax.swing.JTextArea txtViewRedo;
    private javax.swing.JScrollPane txtViewRedoStack;
    private javax.swing.JTabbedPane txtViewUndo;
    private javax.swing.JScrollPane txtViewUndoStack;
    private javax.swing.JScrollPane txtViewWordArray;
    private javax.swing.JTextArea txtViewWordCount;
    private javax.swing.JTextArea txtViewWords;
    // End of variables declaration//GEN-END:variables
}
