import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;

import java.util.ArrayList;
import java.util.List;

import javax.swing.BorderFactory;
import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;


import javax.swing.JTextField;


public class Game {

	public JTextField directionText;

	private JButton startBtn;
	private static final int ROUNDTIME = 30;
	private boolean isClockwise = true;
	private static int timeNow;
	private JFrame frame;
	
	
	public Game() {
		frame = new JFrame("Wheelchair Game");
        frame.setSize(600, 400);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        JPanel panel = new JPanel();
        panel.setBorder(BorderFactory.createEmptyBorder(20, 20, 20, 20));
        
        JPanel textPanel = new JPanel();
        
        directionText = new JTextField(40);
        directionText.setText("Hello");
        directionText.setEditable(false);
        directionText.setHighlighter(null);
        
        textPanel.add(directionText);
        
        JPanel btnPanel = new JPanel();
        startBtn = new JButton("Start");
        startBtn.addActionListener(new StartListener());
        btnPanel.add(startBtn);
        
        panel.add(textPanel);
        panel.add(btnPanel);
        panel.setLayout(new BoxLayout(panel, BoxLayout.PAGE_AXIS));
        frame.setContentPane(panel);
        frame.setVisible(true);
        frame.setResizable(false);
	}
	
    public static void main(String[] args) {
        // TODO Auto-generated method stub
        new Game();
    }
	
	class TimerRunnable implements Runnable {
        @Override
        public void run() {
            //System.out.println(Thread.currentThread().getName());
            for (int i = ROUNDTIME; i > 0; i--) {
                try {
                    Thread.sleep(1000);
                } catch (InterruptedException e1) {
                    e1.printStackTrace();
                }
                countTime(i);
                //System.out.println("count = " + i);
            }
        }
            
            public void countTime(int myTime) {
                myTime -= 1;
                timeNow = myTime;
                if (myTime == 0) {
                    myTime = ROUNDTIME;
                    try {
                        Thread.sleep(2000);
                    } catch (InterruptedException ex) {
                        // TODO Auto-generated catch block
                        ex.printStackTrace();
                    }
                    startBtn.setEnabled(true);
                }
            }
        }
	
	private class StartListener implements ActionListener {
        @Override
        public void actionPerformed(ActionEvent e) {
            startBtn.setEnabled(false);
            timeNow = ROUNDTIME;
            //directionText.setText("Clockwise" + (int)(Math.random() * 12 + 1));
            //scoreNow = 0;
            //scoreField.setText(String.valueOf(scoreNow));
            TimerRunnable timeRunnable = new TimerRunnable();
            Thread timeThread = new Thread(timeRunnable);
            if (!timeThread.isAlive()) {
                timeThread.start();
            }
            while (timeNow > 0) {
            	if (isClockwise) {
                	System.out.println("Clockwise " + (int)(Math.random() * 12 + 1));
                	System.out.println("");
                	//directionText.setText("Clockwise " + (int)(Math.random() * 12 + 1));       

                } else {
                	isClockwise = true;
                	System.out.println("Counterlockwise " + (int)(Math.random() * 12 + 1));
                	System.out.println("");
                	//directionText.setText("Counterclockwise " + (int)(Math.random() * 12 + 1));                   	
                }
            	isClockwise = Math.random() < 0.5;
            	try {
					Thread.sleep(2000);
				} catch (InterruptedException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
            }            
            
            
            
          
        }
    }
	
	
}
